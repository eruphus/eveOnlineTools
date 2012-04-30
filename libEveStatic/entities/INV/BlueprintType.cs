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

namespace libEveStatic.entities.INV
{
    /*
CREATE TABLE dbo.invBlueprintTypes
(
   blueprintTypeID             int,

   parentBlueprintTypeID       int,
   productTypeID               int,

   productionTime              int,
   techLevel                   smallint,
   researchProductivityTime    int,
   researchMaterialTime        int,
   researchCopyTime            int,
   researchTechTime            int,
   productivityModifier        int,
   materialModifier            smallint,
   wasteFactor                 smallint,
   maxProductionLimit          int,

  CONSTRAINT invBlueprintTypes_PK PRIMARY KEY CLUSTERED (blueprintTypeID)

)

     * 
ALTER TABLE invBlueprintTypes ADD CONSTRAINT invBlueprintTypes_FK_blueprintType FOREIGN KEY (blueprintTypeID) REFERENCES invTypes(typeID)
ALTER TABLE invBlueprintTypes ADD CONSTRAINT invBlueprintTypes_FK_parentBlueprintType FOREIGN KEY (parentBlueprintTypeID) REFERENCES invTypes(typeID)
ALTER TABLE invBlueprintTypes ADD CONSTRAINT invBlueprintTypes_FK_productType FOREIGN KEY (productTypeID) REFERENCES invTypes(typeID)

     * */

    public class BlueprintTypeMapper : SubclassMap<BlueprintType>
    {
        public BlueprintTypeMapper()
        {
            Table("invBlueprintTypes");

            KeyColumn("blueprintTypeID");

            References(x => x.ParentBlueprint, "parentBlueprintTypeID");
            References(x => x.Product, "productTypeID");

            Map(x => x.ProductionTime, "productionTime");
            Map(x => x.ResearchProductivityTime, "researchProductivityTime");
            Map(x => x.ResearchMaterialTime, "researchMaterialTime");
            Map(x => x.ResearchCopyTime, "researchCopyTime");
            Map(x => x.ResearchTechTime, "researchTechTime");
            Map(x => x.TechLevel, "techLevel");
            Map(x => x.ProductivityModifier, "productivityModifier");
            Map(x => x.MaterialModifier, "materialModifier");
            Map(x => x.WasteFactor, "wasteFactor");
            Map(x => x.MaxProductionLimit, "maxProductionLimit");

        }
    }

    public class BlueprintType : InventoryType
    {
        public virtual InventoryType ParentBlueprint { get; set; }
        public virtual InventoryType Product { get; set; }

        public virtual int ProductionTime { get; set; }
        public virtual int ResearchProductivityTime { get; set; }
        public virtual int ResearchMaterialTime { get; set; }
        public virtual int ResearchCopyTime { get; set; }
        public virtual int ResearchTechTime { get; set; }
        public virtual int TechLevel { get; set; }
        public virtual int ProductivityModifier { get; set; }
        public virtual int MaterialModifier { get; set; }
        public virtual int WasteFactor { get; set; }
        public virtual int MaxProductionLimit { get; set; }

    }
}