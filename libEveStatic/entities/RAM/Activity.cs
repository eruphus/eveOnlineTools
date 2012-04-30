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

namespace libEveStatic.entities.RAM
{
    /*
CREATE TABLE dbo.ramActivities
(
  activityID     tinyint,
  activityName   nvarchar(100),
  iconNo         varchar(5),
  description    nvarchar(1000),
  published      bit,
  --
  CONSTRAINT ramActivities_PK PRIMARY KEY CLUSTERED (activityID)
)

    */
    public class ActivityMapper : ClassMap<Activity>
    {

        public ActivityMapper()
        {
            Table("ramActivities");
            Id(x => x.Id, "activityID");

            Map(x => x.Name, "activityName").Length(100).Nullable();
            Map(x => x.Description, "description").Length(3000).Nullable();
            Map(x => x.Icon, "iconNo").Length(5).Nullable();
            Map(x => x.Published, "published").Nullable();
        }

    }

    public class Activity 
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string Icon { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Published { get; set; }


        public virtual bool Equals(Activity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Activity)) return false;
            return Equals((Activity) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}