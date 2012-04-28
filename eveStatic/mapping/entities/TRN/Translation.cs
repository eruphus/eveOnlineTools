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

namespace eveStatic.entities.TRN
{
    /*

CREATE TABLE dbo.trnTranslations
(
  tcID        smallint       NOT NULL,
  keyID       int            NOT NULL,
  languageID  varchar(50)    NOT NULL,
  [text]      nvarchar(max)  NOT NULL,
  
  CONSTRAINT trnTranslations_PK PRIMARY KEY CLUSTERED(tcID, keyID, languageID)
)

*/
    public class TranslationMapper : ClassMap<Translation>
    {
        public TranslationMapper ()
        {
            Table("trnTranslations");

            CompositeId().KeyReference(x => x.TranslationColumn, "tcID").KeyProperty(x => x.KeyId, "keyID").KeyProperty(x => x.LanguageId, "languageID");

            References(x => x.TranslationColumn, "tcID");

            Map(x => x.LanguageId, "languageID").Not.Nullable().Length(50);
            Map(x => x.Text, "text").Not.Nullable().Length(16000);
        }

    }


    public class Translation 
    {
        public virtual int KeyId { get; set; }
        public virtual TranslationColumn TranslationColumn { get; set; }
        public virtual string LanguageId { get; set; }

        public virtual string Text { get; set; }

        public virtual bool Equals(Translation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.KeyId == KeyId && Equals(other.TranslationColumn, TranslationColumn) && Equals(other.LanguageId, LanguageId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Translation)) return false;
            return Equals((Translation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = KeyId;
                result = (result*397) ^ (TranslationColumn != null ? TranslationColumn.GetHashCode() : 0);
                result = (result*397) ^ (LanguageId != null ? LanguageId.GetHashCode() : 0);
                return result;
            }
        }
    }    

}