using System;

/**
 * Used for displaying when errors occur
 **/ 
namespace CarRater.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}