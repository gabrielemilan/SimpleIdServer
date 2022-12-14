﻿namespace SimpleIdServer.OAuth
{
    /// <summary>
    /// Confirmation Claim ("cnf") related constants
    /// https://datatracker.ietf.org/doc/html/rfc7800
    /// </summary>
    public class ConfirmationClaimTypes
    {
        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7800#section-6.1.1
        /// </summary>
        public const string Cnf = "cnf";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7800#section-6.2.2
        /// </summary>
        public const string Jwk = "jwk";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7800#section-6.2.2
        /// </summary>
        public const string Jwe = "jwe";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7800#section-6.2.2
        /// </summary>
        public const string Jku = "jku";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7800#section-6.2.2        
        /// </summary>
        public const string Kid = "kid";
    }
}
