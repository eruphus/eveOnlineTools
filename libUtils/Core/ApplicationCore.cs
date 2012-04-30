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
using System.Globalization;
using System.Linq;
using libUtils.I18n;

namespace libUtils.Core
{

    public abstract class ApplicationCore : IDisposable
    {
        private readonly TypedServiceHolder _serviceRepository;
        private List<IPlugin> _plugins;

        protected ApplicationCore()
        {
            if (!_lock) throw new Exception("creation via constructor not allowed");
            _serviceRepository = new TypedServiceHolder();
            _plugins = new List<IPlugin>();
        }


        IEnumerable<Type> GetPluginTypes() 
        {
            return from a in AppDomain.CurrentDomain.GetAssemblies()
                   from t in a.GetTypes()
                   where typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract
                   select t;
        }

        private static readonly object CreationLock = new object();
        private static bool _lock;

        public static T Create<T>() where T : ApplicationCore, new()
        {
            lock (CreationLock)
            {
                if (_singleton != null) throw new Exception("only one core at a time allowed");

                _lock = true;
                var newCore = new T();
                _lock = false;
                _singleton = newCore;
                newCore.Initialize();
                newCore.LoadPlugins();
                return newCore;
            }
        }

        public static ApplicationCore Instance { get { return _singleton; } }
        private static ApplicationCore _singleton;

        private void LoadPlugins()
        {
            foreach (var pluginType in GetPluginTypes())
            {
                var plugin = (IPlugin)Activator.CreateInstance(pluginType);
                
                plugin.Initialize();
                _plugins.Add( plugin);
            }
            
            
        }

        public static void RegisterService<TService>(TService service)
        {
            Instance._serviceRepository.Register(service);
        }

        public static TService GetService<TService>()
        {
            return Instance._serviceRepository.GetService<TService>();
        }

        public virtual void Initialize()
        {
            RegisterService<ICultureProvider>(new StaticCultureProvider(CultureInfo.GetCultureInfo("de")));
            RegisterService<IConfigurationProvider>(new ConfigurationProvider());
        }

        public static CultureInfo CurrentCulture  { get { return GetService<ICultureProvider>().CurrentCulture; } }

        public virtual void Dispose()
        {
            foreach (var plugin in _plugins) plugin.Dispose();
        }
    }
}