/*
    Copyright 2012 Alexander Wölfel 
 
    This file is part of eveStatic.

    eveStatic is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    eveStatic is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

    Diese Datei ist Teil von eveStatic.

    EveStatic ist Freie Software: Sie können es unter den Bedingungen
    der GNU General Public License, wie von der Free Software Foundation,
    Version 3 der Lizenz weiterverbreiten und/oder modifizieren.

    EveStatic wird in der Hoffnung, dass es nützlich sein wird, aber
    OHNE JEDE GEWÄHELEISTUNG, bereitgestellt; sogar ohne die implizite
    Gewährleistung der MARKTFÄHIGKEIT oder EIGNUNG FÜR EINEN BESTIMMTEN ZWECK.
    Siehe die GNU General Public License für weitere Details.

    Sie sollten eine Kopie der GNU General Public License zusammen mit diesem
    Programm erhalten haben. Wenn nicht, siehe <http://www.gnu.org/licenses/>. 
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Linq;
using libNHibernate.Configuration;

namespace libNHibernate
{
    public class DbSession : IDisposable
    {
        private readonly DatabaseConfiguration _configSection;
        private readonly List<Assembly> _assemblies;

        public DbSession(DatabaseConfiguration configSection)
        {
            _configSection = configSection;
            _assemblies = new List<Assembly>();
        }

        public void AddAssemblyByType(Type t)
        {
            AddAssembly(t.Assembly);
        }

        public void AddAssembly(Assembly assembly)
        {
            if (_assemblies.Contains(assembly)) return;
            _assemblies.Add(assembly);
        }

        private void AddMappings(MappingConfiguration mConfig)
        {
            _assemblies.ForEach(x => mConfig.FluentMappings.AddFromAssembly(x));
        }


        private ISessionFactory CreateSession()
        {
            var config = Fluently.Configure().Database(_configSection.Configuration.CreateConfiguration).Mappings(AddMappings);
            return config.BuildSessionFactory();
        }


        private ISession _session;
        private ISession Session { get { return _session ?? (_session = CreateSession().OpenSession()); } }


        public void Dispose()
        {
            if (_session != null)
                _session.Dispose();
        }

        public IDbTransaction OpenTransaction()
        {
            return new TransactionWrapper(Session.BeginTransaction());
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Session.Query<T>();
        }


        public class TransactionWrapper : IDbTransaction
        {
            private readonly ITransaction _transaction;

            public TransactionWrapper(ITransaction transaction)
            {
                _transaction = transaction;
            }

            public void Dispose()
            {
                Rollback();
            }

            public void Commit()
            {
                _transaction.Commit();
            }

            public void Rollback()
            {
                _transaction.Rollback();
            }
        }


    }
}