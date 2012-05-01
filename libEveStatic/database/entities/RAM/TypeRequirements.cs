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

namespace libEveStatic.database.entities.RAM
{
    /*
CREATE TABLE dbo.ramTypeRequirements
(
  typeID          int      NOT NULL,
  activityID      tinyint  NOT NULL,
  requiredTypeID  int      NOT NULL,
  --
  quantity        int      NULL,
  damagePerJob    float    NULL,
  recycle         bit      NULL,
  --
  CONSTRAINT ramTypeRequirements_PK PRIMARY KEY CLUSTERED (typeID, activityID, requiredTypeID)
)
     * 
ALTER TABLE dbo.ramTypeRequirements ADD CONSTRAINT ramTypeRequirements_FK_activity FOREIGN KEY (activityID) REFERENCES ramActivities(activityID)
ALTER TABLE dbo.ramTypeRequirements ADD CONSTRAINT ramTypeRequirements_FK_requiredType FOREIGN KEY (requiredTypeID) REFERENCES invTypes(typeID)

     * * */

    public class TypeRequirementsMapper : ClassMap<TypeRequirements>
    {

        public TypeRequirementsMapper()
        {
            Table("ramInstallationTypeContents");

            CompositeId().KeyProperty(x => x.TypeId, "typeID").KeyReference(x => x.Activity, "activityID").KeyReference(x => x.RequiredType, "requiredTypeID");

            References(x => x.Activity, "activityID");
            References(x => x.RequiredType, "requiredTypeID");

            Map(x => x.Quantity, "quantity").Nullable();
            Map(x => x.DamagePerJob, "damagePerJob").Nullable();
            Map(x => x.Recycle, "recycle").Nullable();
        }

    }

    public class TypeRequirements 
    {
        
        public virtual int TypeId { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual InventoryType RequiredType { get; set; }

        public virtual int Quantity { get; set; }
        public virtual decimal DamagePerJob { get; set; }
        public virtual bool Recycle { get; set; }

        public virtual bool Equals(TypeRequirements other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.TypeId == TypeId && Equals(other.Activity, Activity) && Equals(other.RequiredType, RequiredType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TypeRequirements)) return false;
            return Equals((TypeRequirements) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = TypeId;
                result = (result*397) ^ (Activity != null ? Activity.GetHashCode() : 0);
                result = (result*397) ^ (RequiredType != null ? RequiredType.GetHashCode() : 0);
                return result;
            }
        }
    }
}