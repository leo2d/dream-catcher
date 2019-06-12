﻿using DreamCatcher.Domain.SharedKernel.Interfaces;
using DreamCatcher.Infra.Data.Config;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamCatcher.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T>
    {

        protected ISession Session { get => _session ?? (_session = _connectionFactory.OpenSession()); }
        private ISession _session { get; set; }
        private NHibernateConnectionFactory _connectionFactory;
        public RepositoryBase(NHibernateConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        //public RepositoryBase(ISession session)
        //{
        //    _session = session;
        //}


        public void Create(T entity)
        {
            var tr = Session.BeginTransaction();
            Session.Save(entity);
            tr.Commit();
        }

        public IEnumerable<T> GetAll()
        {
            var result = Session.CreateCriteria(typeof(T)).List<T>();

            return result;
        }

        public T GetById(Guid id)
        {
            return Session.Get<T>(id);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);

        }
    }
}