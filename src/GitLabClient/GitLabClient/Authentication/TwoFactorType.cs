namespace GitLabClient
{
    /// <summary>
    /// Methods for receiving 2FA authentication codes
    /// </summary>
    public enum TwoFactorType
    {
        /// <summary>
        /// No method configured
        /// </summary>
        None,

        /// <summary>
        /// Unknown method
        /// </summary>
        Unknown,

        /// <summary>
        /// Receive via SMS
        /// </summary>
        Sms,

        /// <summary>
        /// Receive via application
        /// </summary>
        AuthenticatorApp
    }
}
