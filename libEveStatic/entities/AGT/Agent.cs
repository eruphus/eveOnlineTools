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
using libEveStatic.entities.CRP;
using libEveStatic.entities.INV;

namespace libEveStatic.entities.AGT
{
    /*
CREATE TABLE dbo.agtAgents
(
  agentID        int,
  divisionID     tinyint,
  corporationID  int,
  locationID     int,
  [level]        tinyint,
  quality        smallint,
  agentTypeID    int,
  isLocator      bit,

  CONSTRAINT agtAgents_PK PRIMARY KEY CLUSTERED (agentID)
)
CREATE NONCLUSTERED INDEX agtAgents_IX_corporation ON agtAgents (corporationID)
CREATE NONCLUSTERED INDEX agtAgents_IX_station ON agtAgents (locationID)

     * 
ALTER TABLE agtAgents ADD CONSTRAINT agtAgents_FK_agent FOREIGN KEY (agentID) REFERENCES invNames(itemID)
ALTER TABLE agtAgents ADD CONSTRAINT agtAgents_FK_division FOREIGN KEY (divisionID) REFERENCES crpNPCDivisions(divisionID)
ALTER TABLE agtAgents ADD CONSTRAINT agtAgents_FK_corporation FOREIGN KEY (corporationID) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE agtAgents ADD CONSTRAINT agtAgents_FK_agentType FOREIGN KEY (agentTypeID) REFERENCES agtAgentTypes(agentTypeID)
Todo: search a solution for locationID

     */

    public class AgentMapper : SubclassMap<Agent>
    {
        public AgentMapper() 
        {
            Table("agtAgents");
            KeyColumn("agentID");

            HasManyToMany(x => x.ResearchTypes).AsBag().Not.Inverse().ParentKeyColumn("agentID").ChildKeyColumn("typeID")
                .Table("agtResearchAgents");

            References(x => x.AgentType, "agentTypeID").Nullable();
            References(x => x.Division, "divisionID").Nullable();
            References(x => x.Corporation, "corporationID").Nullable();
            Map(x => x.LocationID, "locationID").Nullable();

            Map(x => x.Level, "level").Nullable();
            Map(x => x.Quality, "quality").Nullable();
            Map(x => x.IsLocator, "isLocator").Nullable();

        }
    }


    public class Agent : InventoryName
    {

        public Agent()
        {
            ResearchTypes = new List<InventoryType>();
        }

        
        public virtual ICollection<InventoryType> ResearchTypes { get; set; }

        public virtual NpcDevision Division { get; set; }
        public virtual AgentType AgentType { get; set; }
        public virtual NpcCorporation Corporation { get; set; }
        public virtual int LocationID { get; set; }

        public virtual int Level { get; set; }
        public virtual int Quality { get; set; }
        public virtual bool IsLocator { get; set; }


    }
}