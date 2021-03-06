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


namespace libUtils.Core
{
    public interface IConfigurationProvider
    {
        T GetConfiguration<T>(string sectionName) where T : BaseConfiguration<T>;
    }


    public class ConfigurationProvider : IConfigurationProvider
    {
        public virtual T GetConfiguration<T>(string sectionName) where T : BaseConfiguration<T>
        {
            return BaseConfiguration<T>.Load(sectionName);
        }
    }

    public class GroupConfigurationProvider : ConfigurationProvider
    {
        private readonly string _groupName;

        public GroupConfigurationProvider(string groupName) { _groupName = groupName; }

        public override T GetConfiguration<T>(string sectionName)
        {
            return base.GetConfiguration<T>(_groupName + "/" + sectionName);
        }
    }


}