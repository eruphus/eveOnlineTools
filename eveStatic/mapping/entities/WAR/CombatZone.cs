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

namespace eveStatic.entities.WAR
{


    /*
CREATE TABLE dbo.warCombatZones
(
  combatZoneID    int            NOT NULL DEFAULT -1,
  combatZoneName  nvarchar(100)  NULL,
  factionID       int            NULL,
  centerSystemID  int            NULL,
  description     nvarchar(500)  NULL,
  CONSTRAINT combatZones_PK PRIMARY KEY CLUSTERED (combatZoneID)
)     * 
     * 
     * 
     */

    public class CombatZoneMapper : ClassMap<CombatZone>
    {
        public CombatZoneMapper ()
        {
            Table("warCombatZones");
            Id(x => x.Id, "combatZoneID").Not.Nullable();

            Map(x => x.FactionId, "factionID").Nullable();
            Map(x => x.CenterSytemId, "centerSystemID").Nullable();

            Map(x => x.CombatZoneName, "combatZoneName").Length(100).Nullable();
            Map(x => x.Description, "description").Length(500).Nullable();
        }
    }


    public class CombatZone 
    {
        public virtual int Id { get; set; }

        public virtual int FactionId { get; set; }
        public virtual int CenterSytemId { get; set; }
        
        public virtual string CombatZoneName { get; set; }
        public virtual string Description { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, CombatZoneName);
        }
    }
}