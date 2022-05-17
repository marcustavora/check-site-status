using System;

namespace SiteStatus.Domain.DTOs
{
    public class StatusDTO
    {
        #region [ Constructors ]

        public StatusDTO()
        {
        }

        public StatusDTO(string uri, bool isUp, DateTime checkDate)
        {
            Uri = uri;
            IsUp = isUp;
            CheckDate = checkDate;
        }

        #endregion

        #region [ Properties ]

        public long Id { get; set; }

        public string Uri { get; set; }

        public bool IsUp { get; set; }

        public DateTime CheckDate { get; set; }

        #endregion

        #region [ Methods ]

        #endregion
    }
}