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

using System;
using FluentNHibernate.Mapping;
using libEveStatic.database.entities.CRP;
using libEveStatic.database.entities.STA;

namespace libEveStatic.database.entities.RAM
{
    /*
CREATE TABLE dbo.ramAssemblyLines
(
  assemblyLineID                int,
  assemblyLineTypeID            tinyint,
  containerID                   int, -- where it is (stationID)
  nextFreeTime                  smalldatetime,
  UIGroupingID                  tinyint, --user defined groupings (within a containment)
  costInstall                   float,
  costPerHour                   float,
  restrictionMask               tinyint, -- (0 = not, 1 = by security, 2 = by standing, 4 = corp, 8 = alliance)
  discountPerGoodStandingPoint  float,
  surchargePerBadStandingPoint  float,
  minimumStanding               float,
  minimumCharSecurity           float,
  minimumCorpSecurity           float,
  maximumCharSecurity           float,
  maximumCorpSecurity           float,
  ownerID                       int,
  activityID                    tinyint,
  --
  CONSTRAINT ramAssemblyLines_PK PRIMARY KEY CLUSTERED (assemblyLineID)
)
CREATE NONCLUSTERED INDEX ramAssemblyLines_IX_container ON ramAssemblyLines (containerID)
CREATE NONCLUSTERED INDEX ramAssemblyLines_IX_owner ON ramAssemblyLines (ownerID)

ALTER TABLE ramAssemblyLines ADD CONSTRAINT ramAssemblyLines_FK_assemblyLineType FOREIGN KEY (assemblyLineTypeID) REFERENCES ramAssemblyLineTypes(assemblyLineTypeID)
ALTER TABLE ramAssemblyLines ADD CONSTRAINT ramAssemblyLines_FK_container FOREIGN KEY (containerID) REFERENCES staStations(stationID) 
ALTER TABLE ramAssemblyLines ADD CONSTRAINT ramAssemblyLines_FK_owner FOREIGN KEY (ownerID) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE ramAssemblyLines ADD CONSTRAINT ramAssemblyLines_FK_activity FOREIGN KEY (activityID) REFERENCES ramActivities(activityID)
*/

    public class AssemblyLineMapper : ClassMap<AssemblyLine>
    {
        public AssemblyLineMapper()
        {
            Table("ramAssemblyLines");
            Id(x => x.Id, "assemblyLineID");

            References(x => x.Activity, "activityID");
            References(x => x.AssemblyLineType, "assemblyLineTypeID").Nullable();
            References(x => x.Station, "containerID").Nullable();
            References(x => x.Owner, "ownerID").Nullable();

            Map(x => x.NextFreeTime, "nextFreeTime").Nullable();
            Map(x => x.UiGroupingId, "UIGroupingID").Nullable();
            Map(x => x.InstallCost, "costInstall").Nullable();
            Map(x => x.PerHourCost, "costPerHour").Nullable();
            Map(x => x.RestictionMask, "restrictionMask").Nullable().CustomType<int>();
            Map(x => x.DiscountPerGoodStandingPoint, "discountPerGoodStandingPoint").Nullable();
            Map(x => x.SurchargePerBadStandingPoint, "surchargePerBadStandingPoint").Nullable();
            Map(x => x.MinimumStanding, "minimumStanding").Nullable();
            Map(x => x.MinimumCharSecurity, "minimumCharSecurity").Nullable();
            Map(x => x.MinimumCorpSecurity, "minimumCorpSecurity").Nullable();
            Map(x => x.MaximumCharSecurity, "maximumCharSecurity").Nullable();
            Map(x => x.MaximumCorpSecurity, "maximumCorpSecurity").Nullable();
        }
    }


    public class AssemblyLine 
    {
        public virtual int Id { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual AssemblyLineType AssemblyLineType { get; set; }
        public virtual Station Station { get; set; }
        public virtual NpcCorporation Owner { get; set; }

        public virtual DateTime NextFreeTime { get; set; }
        public virtual int UiGroupingId { get; set; }
        public virtual decimal InstallCost { get; set; }
        public virtual decimal PerHourCost { get; set; }
        public virtual AssemblyLineRestriction RestictionMask { get; set; }
        public virtual decimal DiscountPerGoodStandingPoint { get; set; }
        public virtual decimal SurchargePerBadStandingPoint { get; set; }
        public virtual decimal MinimumStanding { get; set; }
        public virtual decimal MinimumCharSecurity { get; set; }
        public virtual decimal MinimumCorpSecurity { get; set; }
        public virtual decimal MaximumCharSecurity { get; set; }
        public virtual decimal MaximumCorpSecurity { get; set; }


    }

    
    public enum AssemblyLineRestriction
    {
        NoRestriction = 0,
        BySecurity = 1,
        ByStanding = 2,
        Corp = 4,
        Alliance = 8
    }
}