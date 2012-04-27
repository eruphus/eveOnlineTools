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

using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace eveStatic.entities.PLA
{
    /*

CREATE TABLE dbo.planetSchematics
(
  schematicID     smallint,
  schematicName   nvarchar(255),
  cycleTime       int,

  CONSTRAINT planetSchematics_PK PRIMARY KEY CLUSTERED (schematicID)
)
     * 
     * 

    */

    public class PlanetSchematicMapper : ClassMap<PlanetSchematic>
    {
        public PlanetSchematicMapper()
        {
            Table("planetSchematics");

            Id(x => x.Id, "schematicID");

            Map(x => x.SchematicName, "schematicName").Nullable().Length(255);
            Map(x => x.CycleTime, "cycleTime").Nullable();

            HasMany(x => x.Materials).KeyColumn("schematicID").AsBag().Not.Inverse(); 

        }
    }

    public class PlanetSchematic 
    {
        public PlanetSchematic ()
        {
            Materials = new List<PlanetSchematicsTypeMap>();
        }

        public virtual int Id { get; set; }

        public virtual ICollection<PlanetSchematicsTypeMap> Materials { get; set; }


        public virtual string SchematicName  { get; set; }
        public virtual int CycleTime { get; set; }

        public virtual bool Equals(PlanetSchematic other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (PlanetSchematic)) return false;
            return Equals((PlanetSchematic) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}