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
using libEveStatic.mappers;
using libEveStatic.types;

namespace libEveStatic.entities.INV
{
    /*
CREATE TABLE dbo.invPositions
(
    itemID  bigint  NOT NULL,
    x       float   NOT NULL  DEFAULT 0.0,
    y       float   NOT NULL  DEFAULT 0.0,
    z       float   NOT NULL  DEFAULT 0.0,
    yaw     real    NULL,
    pitch   real    NULL,
    roll    real    NULL,
    --
    CONSTRAINT invPositions_PK PRIMARY KEY CLUSTERED (itemID)
)

ALTER TABLE invPositions ADD CONSTRAINT invPositions_FK_location FOREIGN KEY (itemID) REFERENCES invItems(itemID) 

     * 

CREATE TABLE dbo.mapJumps
(
  stargateID   int,
  celestialID  int,
  --
  CONSTRAINT mapJumps_PK PRIMARY KEY CLUSTERED (stargateID)
)
     * 
     * 
ALTER TABLE mapJumps ADD CONSTRAINT mapJumps_FK_celestial FOREIGN KEY (celestialID) REFERENCES invPositions(itemID)
ALTER TABLE mapJumps ADD CONSTRAINT mapJumps_FK_stargate FOREIGN KEY (stargateID) REFERENCES invPositions(itemID)
     * * 
    */
    public class InventoryPositionMapper :  SubclassMapper<InventoryPosition>
    {
        public InventoryPositionMapper()
        {
            Table("invPositions");
            KeyColumn("itemID");

            HasManyToMany(x => x.CelestialJumps).Table("mapJumps").ParentKeyColumn("stargateID").ChildKeyColumn("celestialID").Not.Inverse();

            MapLocation(x => x.Location,"x", "y", "z");

            Map(x => x.Yaw, "yaw").Nullable();
            Map(x => x.Pitch, "pitch").Nullable();
            Map(x => x.Roll, "roll").Nullable();
        }
    }

    public class InventoryPosition : InventoryItem
    {

        public InventoryPosition()
        {
            CelestialJumps = new List<InventoryPosition>();  
        }
        
        public virtual Location Location { get; set; }

        public virtual ICollection<InventoryPosition> CelestialJumps { get; set; }

        public virtual decimal Yaw { get; set; }
        public virtual decimal Pitch { get; set; }
        public virtual decimal Roll { get; set; }
    }
}