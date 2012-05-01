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

using FluentNHibernate.Mapping;

namespace libEveStatic.database.entities.RAM
{
    /*
CREATE TABLE dbo.ramInstallationTypeContents
(
  installationTypeID  int      NOT NULL,
  assemblyLineTypeID  tinyint  NOT NULL,
  --
  quantity            tinyint  NULL,
  CONSTRAINT ramInstallationTypeContents_PK PRIMARY KEY CLUSTERED (installationTypeID, assemblyLineTypeID)
)
     * */

    public class InstallationTypeContentMapper : ClassMap<InstallationTypeContent>
    {

        public InstallationTypeContentMapper()
        {
            Table("ramInstallationTypeContents");

            CompositeId().KeyProperty(x => x.InstallationTypeId, "installationTypeID").KeyProperty(x => x.AssemblyLineTypeId, "assemblyLineTypeID");

            Map(x => x.Quantity, "quantity").Nullable();
        }

    }

    public class InstallationTypeContent 
    {

        public virtual int InstallationTypeId { get; set; }
        public virtual int AssemblyLineTypeId { get; set; }

        public virtual int Quantity { get; set; }

        public virtual bool Equals(InstallationTypeContent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.AssemblyLineTypeId == AssemblyLineTypeId && other.InstallationTypeId == InstallationTypeId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (InstallationTypeContent)) return false;
            return Equals((InstallationTypeContent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (AssemblyLineTypeId*397) ^ InstallationTypeId;
            }
        }
    }
}