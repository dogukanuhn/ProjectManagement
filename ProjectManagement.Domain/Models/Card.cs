using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProjectManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Domain.Models
{
    public class Card : BaseModelEntity
    {
        public Card()
        {
            IsDone = false;
            IsWarned = false;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }
        public bool IsWarned { get; set; }
        public string CreatedBy { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? Created { get; set; }
        public string LastModifiedBy { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? LastModified { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ExpireTime { get; set; }

        public string NotificationEmail { get; set; }

    }
}
