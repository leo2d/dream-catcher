using DreamCatcher.Infra.Data.Mapping;
using DreamCatcher.Infra.Data.Repositories;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Context;
using NHibernate.Mapping.ByCode;
using System;
using System.Data;
using System.Reflection;
using System.Web;

namespace DreamCatcher.Infra.Data.Config
{
    public class NHibernateConnectionFactory
    {
        private Configuration _configuration;
        private ISession _session;
        private ISessionFactory _sessionFactory;

        private const string _connectionString =
            "Persist Security Info=False;server=localhost;port=3306;database=dream_catcher_db;uid=root;pwd=";

        public UserRepository UserRepository { get; set; }

        public NHibernateConnectionFactory()
        {
            _configuration = new Configuration();
            Configure();
            _sessionFactory = _configuration.BuildSessionFactory();

            //      InitializeDB();

            //UserRepository = new UserRepository(Session);
        }

        private void Configure()
        {
            try
            {
                //Integração com o Banco de Dados
                _configuration.DataBaseIntegration(c =>
                {
                    //Dialeto de Banco
                    c.Dialect<NHibernate.Dialect.MySQLDialect>();
                    //Conexao string
                    c.ConnectionString = _connectionString;
                    //Drive de conexão com o banco
                    c.Driver<NHibernate.Driver.MySqlDataDriver>();
                    // Provedor de conexão do MySQL 
                    c.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                    // GERA LOG DOS SQL EXECUTADOS NO CONSOLE
                    c.LogSqlInConsole = true;
                    // DESCOMENTAR CASO QUEIRA VISUALIZAR O LOG DE SQL FORMATADO NO CONSOLE
                    c.LogFormattedSql = true;
                    // CRIA O SCHEMA DO BANCO DE DADOS SEMPRE QUE A CONFIGURATION FOR UTILIZADA
                    c.SchemaAction = SchemaAutoAction.Update;
                });

                //Realiza o mapeamento das classes
                var maps = AddMappings();
                _configuration.AddMapping(maps);

                _configuration.CurrentSessionContext<WebSessionContext>();

                _sessionFactory = _configuration.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                InitializeDB();
                //     throw new Exception("Não foi possível conectar o NHibernate.", ex);
            }

        }

        private void InitializeDB()
        {
            try
            {
                var mySql = new MySqlConnection(_connectionString);
                try
                {
                    mySql.Open();
                }
                catch
                {
                    try
                    {
                        var mySqlCon =
                            new MySqlConnection("server=localhost;port=3306;uid=root;pwd=");

                        var dbName = "dream_catcher_db";
                        var cmd = mySqlCon.CreateCommand();

                        mySqlCon.Open();
                        cmd.CommandText = $"CREATE DATABASE IF NOT EXISTS `{dbName}`;";
                        cmd.ExecuteNonQuery();
                        mySqlCon.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Não foi criar o banco de dados.", ex);
                    }
                    //CriarSchemaBanco(server, port, dbName, psw, user);
                }
                finally
                {
                    if (mySql.State == ConnectionState.Open)
                    {
                        mySql.Close();
                    }
                }

                //ConexaoNHibernate(_connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar ao banco de dados.", ex);
            }
        }

        private HbmMapping AddMappings()
        {
            try
            {
                var mapper = new ModelMapper();

                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(DreamMap)).GetTypes()
                );

                return mapper.CompileMappingForAllExplicitlyAddedEntities();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar o mapeamento do modelo.", ex);
            }
        }

        public ISession OpenSession()
        {
            if (_session == null)
            {
                _session = _sessionFactory.OpenSession();
                if (CurrentSessionContext.HasBind(_sessionFactory))
                    return _sessionFactory.GetCurrentSession();

                _session = _sessionFactory.OpenSession();
                _session.FlushMode = FlushMode.Commit;

                CurrentSessionContext.Bind(_session);

                return _session;
            }

            return _session;
        }

        public void CloseSession()
        {
            if (_session != null && _session.IsOpen)
            {
                _session.Flush();
                _session.Close();
            }

            _session = null;
        }

        #region original

        private static NHibernateConnectionFactory _instance = null;

        public static NHibernateConnectionFactory Instance => _instance ?? (_instance = new NHibernateConnectionFactory());

        //public ISession Session
        //{
        //    get
        //    {
        //        try
        //        {
        //            if (CurrentSessionContext.HasBind(_sessionFactory))
        //                return _sessionFactory.GetCurrentSession();

        //            var session = _sessionFactory.OpenSession();
        //            session.FlushMode = FlushMode.Commit;

        //            CurrentSessionContext.Bind(session);

        //            return session;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Não foi possível criar a Sessão.", ex);
        //        }
        //    }
        //}

        private void ConexaoNHibernate(string stringConexao)
        {
            //Cria a configuração com o NH
            var config = new Configuration();
            try
            {

                //Integração com o Banco de Dados
                config.DataBaseIntegration(c =>
                {
                    //Dialeto de Banco
                    c.Dialect<NHibernate.Dialect.MySQLDialect>();
                    //Conexao string
                    c.ConnectionString = stringConexao;
                    //Drive de conexão com o banco
                    c.Driver<NHibernate.Driver.MySqlDataDriver>();
                    // Provedor de conexão do MySQL 
                    c.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                    // GERA LOG DOS SQL EXECUTADOS NO CONSOLE
                    c.LogSqlInConsole = true;
                    // DESCOMENTAR CASO QUEIRA VISUALIZAR O LOG DE SQL FORMATADO NO CONSOLE
                    c.LogFormattedSql = true;
                    // CRIA O SCHEMA DO BANCO DE DADOS SEMPRE QUE A CONFIGURATION FOR UTILIZADA
                    c.SchemaAction = SchemaAutoAction.Update;
                });

                //Realiza o mapeamento das classes
                var maps = this.AddMappings();
                config.AddMapping(maps);

                //Verifico se a aplicação é Desktop ou Web
                if (HttpContext.Current == null)
                {
                    config.CurrentSessionContext<ThreadStaticSessionContext>();
                }
                else
                {
                    config.CurrentSessionContext<WebSessionContext>();
                }

                this._sessionFactory = config.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar o NHibernate.", ex);
            }
        }


        private void CriarSchemaBanco(string server, string port, string dbName, string psw, string user)
        {
            try
            {
                var stringConexao = "server=" + server + ";user=" + user + ";port=" + port + ";password=" + psw + ";";
                var mySql = new MySqlConnection(stringConexao);
                var cmd = mySql.CreateCommand();

                mySql.Open();
                cmd.CommandText = "CREATE DATABASE IF NOT EXISTS `" + dbName + "`;";
                cmd.ExecuteNonQuery();
                mySql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi criar o banco de dados.", ex);
            }
        }
        #endregion
    }
}
