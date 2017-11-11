
using System;
using System.ComponentModel.DataAnnotations;

namespace convertizzle.Models
{
    /// <summary>
    /// This class describes one pdf conversion
    /// </summary>
    public class Conversion
    {

        /// <summary>
        /// The unique id of the conversion
        /// </summary>
        [Key]
        public Guid Id { get;  set;}

        /// <summary>
        /// The account the conversion was done for
        /// </summary>
        public virtual Account Account {get; set;}

        /// <summary>
        /// The Date/Time the conversion started
        /// </summary>
        public DateTime ConversionStarted { get; set; }

        /// <summary>
        /// The Date/Time the conversion ended. If null 
        /// the conversion did not yet finish
        /// </summary>
        public DateTime? ConversionEnded{ get; set; }

        /// <summary>
        /// The time it took to convert the file
        /// </summary>
        public TimeSpan ConversionDuration { get; set; }

        /// <summary>
        /// The size of the original content to convert
        /// </summary>
        public double OriginalContentSize { get; set; } 

        /// <summary>
        /// The side of the converted content
        /// </summary>
        public double ConvertedContentSize { get; set;}

        /// <summary>
        /// Returns true, when the conversion succeeded
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// The detailed exception details in case of a failure
        /// </summary>
        public string ExceptionDetails { get; set; }

        /// <summary>
        /// The url of the converted file. If null the conversion 
        /// was with a specified text instead of an url
        /// </summary>
        public string Filename { get; set; }

    }
}