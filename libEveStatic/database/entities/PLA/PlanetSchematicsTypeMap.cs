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
using libEveStatic.database.entities.INV;

namespace libEveStatic.database.entities.PLA
{
    /*
CREATE TABLE dbo.planetSchematicsTypeMap
(
  schematicID     smallint,
  typeID          int,
  quantity        smallint,
  isInput         bit,

  CONSTRAINT planetSchematicsTypeMap_PK PRIMARY KEY CLUSTERED (schematicID, typeID)
)
     * 
     * */

    public class PlanetSchematicsTypeMapMapper : ClassMap<PlanetSchematicsTypeMap>
    {
        public PlanetSchematicsTypeMapMapper()
        {
            Table("planetSchematicsTypeMap");

            CompositeId().KeyReference(x => x.Schematic, "schematicID").KeyReference(x => x.Type, "typeID");
            
            References(x => x.Type, "typeID");
            References(x => x.Schematic, "schematicID");

            Map(x => x.Quantity, "quantity");
            Map(x => x.IsInput, "isInput");


        }
    }

    public class PlanetSchematicsTypeMap 
    {
        public virtual PlanetSchematic Schematic { get; set; }
        public virtual InventoryType Type { get; set; }
        public virtual int Quantity { get; set; }
        public virtual bool IsInput { get; set; }

        public virtual bool Equals(PlanetSchematicsTypeMap other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Schematic, Schematic) && Equals(other.Type, Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (PlanetSchematicsTypeMap)) return false;
            return Equals((PlanetSchematicsTypeMap) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Schematic != null ? Schematic.GetHashCode() : 0)*397) ^ (Type != null ? Type.GetHashCode() : 0);
            }
        }
    }
}