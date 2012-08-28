using System.Runtime.Serialization;


namespace ED_LearnPad_Core.DTOs
{
    public class UserDto
    {
        [DataMember]
        public string UserLoginName { get; set; }

        [DataMember]
        public string UserFullName { get; set; }

        [DataMember]
        public string UserFirstName { get; set; }
        
        [DataMember]
        public string UserLastName { get; set; }
        
        [DataMember]
        public string UserZipCode { get; set; }
        
        [DataMember]
        public string LoginGuid { get; set; }

        [DataMember]
        public int LoginId { get; set; }

        [DataMember]
        public bool UserValidLogin { get; set; }


    }
}
