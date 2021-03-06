/*
    Copyright 2012 Alexander W�lfel 
 
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

    EveStatic ist Freie Software: Sie k�nnen es unter den Bedingungen
    der GNU General Public License, wie von der Free Software Foundation,
    Version 3 der Lizenz weiterverbreiten und/oder modifizieren.

    EveStatic wird in der Hoffnung, dass es n�tzlich sein wird, aber
    OHNE JEDE GEW�HELEISTUNG, bereitgestellt; sogar ohne die implizite
    Gew�hrleistung der MARKTF�HIGKEIT oder EIGNUNG F�R EINEN BESTIMMTEN ZWECK.
    Siehe die GNU General Public License f�r weitere Details.

    Sie sollten eine Kopie der GNU General Public License zusammen mit diesem
    Programm erhalten haben. Wenn nicht, siehe <http://www.gnu.org/licenses/>. 
 
 */

using System.Xml.Serialization;
using FluentNHibernate.Cfg.Db;

namespace libNHibernate.Configuration
{

    public class MySqlConfiguration : AbstractDatabaseConfiguration<MySQLConfiguration, MySQLConnectionStringBuilder> 
    {
        [XmlElement("server")] public string Server { get; set; } 
        [XmlElement("user")] public string User { get; set; }
        [XmlElement("password")] public string Password { get; set; }
        [XmlElement("schema")] public string Schema { get; set; }

        protected override MySQLConfiguration GetConfigurationInstance()
        {
            return MySQLConfiguration.Standard;
        }

        protected override void ApplyConnectionString(MySQLConnectionStringBuilder builder)
        {
            builder.Database(Schema).Username(User).Password(Password).Server(Server);
        }
    }
}