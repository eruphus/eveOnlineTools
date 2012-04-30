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
using libEveStatic.entities.INV;

namespace libEveStatic.entities.RAM
{

    /*

CREATE TABLE dbo.ramAssemblyLineTypeDetailPerGroup
(
  assemblyLineTypeID  tinyint,
  groupID             int,
  timeMultiplier      float,
  materialMultiplier  float,
  --
  CONSTRAINT ramAssemblyLineTypeDetailPerGroup_PK PRIMARY KEY CLUSTERED (assemblyLineTypeID, groupID)
     * 
     * 
     * 

)


ALTER TABLE ramAssemblyLineTypeDetailPerGroup ADD CONSTRAINT ramAssemblyLineTypeDetailPerGroup_FK_assemblyLineType FOREIGN KEY (assemblyLineTypeID) REFERENCES ramAssemblyLineTypes(assemblyLineTypeID)
ALTER TABLE ramAssemblyLineTypeDetailPerGroup ADD CONSTRAINT ramAssemblyLineTypeDetailPerGroup_FK_group FOREIGN KEY (groupID) REFERENCES invGroups(groupID)


*/

    public class AssemblyLineTypeDetailPerGroupMapper : ClassMap<AssemblyLineTypeDetailPerGroup>
    {
        public AssemblyLineTypeDetailPerGroupMapper()
        {
            Table("ramAssemblyLineTypeDetailPerGroup");

            CompositeId().KeyReference(x => x.AssemblyLineType, "assemblyLineTypeID").KeyReference(x => x.Group, "groupID");

            References(x => x.AssemblyLineType, "assemblyLineTypeID");
            References(x => x.Group, "groupID");

            Map(x => x.TimeMultipliey, "timeMultiplier");
            Map(x => x.MaterialMultiplier, "materialMultiplier");
        }

    }

    public class AssemblyLineTypeDetailPerGroup 
    {
        public virtual AssemblyLineType AssemblyLineType { get; set; }
        public virtual InventoryGroup Group { get; set; }

        public virtual decimal TimeMultipliey { get; set; }
        public virtual decimal MaterialMultiplier { get; set; }

        public virtual bool Equals(AssemblyLineTypeDetailPerCategory other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.AssemblyLineType, AssemblyLineType) && Equals(other.Category, Group);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(AssemblyLineTypeDetailPerCategory)) return false;
            return Equals((AssemblyLineTypeDetailPerCategory)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((AssemblyLineType != null ? AssemblyLineType.GetHashCode() : 0) * 397) ^ (Group != null ? Group.GetHashCode() : 0);
            }
        }
    }

}