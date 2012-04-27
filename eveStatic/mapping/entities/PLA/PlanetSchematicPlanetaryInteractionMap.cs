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
using eveStatic.entities.INV;

namespace eveStatic.entities.PLA
{
    /*
     * 
CREATE TABLE dbo.planetSchematicsPinMap
(
  schematicID     smallint,
  pinTypeID       int,

  CONSTRAINT planetSchematicsPinMap_PK PRIMARY KEY CLUSTERED (schematicID, pinTypeID)
)

     * * */

    public class PlanetSchematicPlanetaryInteractionMapMapper : ClassMap<PlanetSchematicPlanetaryInteractionMap>
    {
        public PlanetSchematicPlanetaryInteractionMapMapper()
        {
            Table("planetSchematicsPinMap");

            CompositeId().KeyReference(x => x.Schematic, "schematicID").KeyReference(x => x.PiType, "pinTypeID");

            References(x => x.Schematic, "schematicID");
            References(x => x.PiType, "pinTypeID");


        }
    }

    public class PlanetSchematicPlanetaryInteractionMap 
    {
        public virtual PlanetSchematic Schematic { get; set; }
        public virtual InventoryType PiType { get; set; }


        public virtual bool Equals(PlanetSchematicPlanetaryInteractionMap other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Schematic, Schematic) && Equals(other.PiType, PiType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(PlanetSchematicPlanetaryInteractionMap)) return false;
            return Equals((PlanetSchematicPlanetaryInteractionMap)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Schematic != null ? Schematic.GetHashCode() : 0) * 397) ^ (PiType != null ? PiType.GetHashCode() : 0);
            }
        }


    }
}