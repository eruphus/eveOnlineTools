﻿/*
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

namespace eveStatic.entities.AGT
{

    /*

CREATE TABLE dbo.agtResearchAgents
(
  agentID      int,
  typeID       int,

  CONSTRAINT agtResearchAgents_PK PRIMARY KEY CLUSTERED (agentID, typeID)
)

     * 
ALTER TABLE agtResearchAgents ADD CONSTRAINT agtResearchAgents_FK_agent FOREIGN KEY (agentID) REFERENCES agtAgents(agentID)
ALTER TABLE agtResearchAgents ADD CONSTRAINT agtResearchAgents_FK_type FOREIGN KEY (typeID) REFERENCES invTypes(typeID)

    */

    public class ResearchAgentMapper : ClassMap<ResearchAgent>
    {
        public ResearchAgentMapper()
        {
            Table("agtResearchAgents");

            CompositeId().KeyReference(x => x.Agent, "agentID").KeyReference(x => x.Type, "typeID");

            References(x => x.Agent, "agentID");
            References(x => x.Type, "typeID");
        }
    }


    public class ResearchAgent 
    {
        public virtual Agent Agent { get; set; }
        public virtual InventoryType Type { get; set; }

        public virtual bool Equals(ResearchAgent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Agent, Agent) && Equals(other.Type, Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ResearchAgent)) return false;
            return Equals((ResearchAgent)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Agent != null ? Agent.GetHashCode() : 0) * 397) ^ (Type != null ? Type.GetHashCode() : 0);
            }
        }

    }
}