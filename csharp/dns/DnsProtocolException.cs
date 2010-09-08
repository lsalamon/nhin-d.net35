﻿/* 
 Copyright (c) 2010, NHIN Direct Project
 All rights reserved.

 Authors:
    Umesh Madan     umeshma@microsoft.com
    Sean Nolan      seannol@microsoft.com
 
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
Neither the name of the The NHIN Direct Project (nhindirect.org). nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnsResolver
{
    /// <summary>
    /// Enumeration of errors for <see cref="DnsProtocolException"/>
    /// </summary>
    public enum DnsProtocolError
    {
        /// <summary>
        /// Unspecified
        /// </summary>
        None = 0,
        /// <summary>
        /// Failure
        /// </summary>
        Failed,
        /// <summary>
        /// Hit max retries
        /// </summary>
        MaxAttemptsReached,
        /// <summary>
        /// DNS label was longer than specified
        /// </summary>
        LabelTooLong,
        /// <summary>
        /// The Raw String was longer than specified
        /// </summary>
        StringTooLong,
        /// <summary>
        /// Request ID did not match Response ID
        /// </summary>
        RequestIDMismatch,
        /// <summary>
        /// Number of questions was set to an invalid number
        /// </summary>
        InvalidQuestionCount,
        /// <summary>
        /// QNAME was set to an invalid value.
        /// </summary>
        InvalidQName,
        /// <summary>
        /// If the domain name was mangled and could not serialized correctly
        /// </summary>
        InvalidPath,
        /// <summary>
        /// Answer count (ADCOUNT) was set to an invalid value.
        /// </summary>
        InvalidAnswerCount,
        /// <summary>
        /// Nameserver Count (NSCOUNT)was set to an invalid value.
        /// </summary>
        InvalidNameServerAnswerCount,
        /// <summary>
        /// Additional answer count (ARCOUNT) was set to an invalid value.
        /// </summary>
        InvalidAdditionalAnswerCount,
        /// <summary>
        /// Record name was set to an invalid value (e.g., <c>null</c>)
        /// </summary>
        InvalidRecordName,
        /// <summary>
        /// Record size was set to an invalid value (e.g., 0)
        /// </summary>
        InvalidRecordSize,
        /// <summary>
        /// Record count was set to an invalid value (e.g., 0)
        /// </summary>
        InvalidRecordCount,
        /// <summary>
        /// TTL was set to an invalid value (e.g., 0)
        /// </summary>
        InvalidTTL,
        /// <summary>
        /// Record was invalid (e.g., <c>null</c>, zero length, etc.)
        /// </summary>
        InvalidRecord,
        /// <summary>
        /// A RR was invalid
        /// </summary>
        InvalidARecord,
        /// <summary>
        /// NS RR was invalid.
        /// </summary>
        InvalidNSRecord,
        /// <summary>
        /// PTR RR was invalid
        /// </summary>
        InvalidPtrRecord,
        /// <summary>
        /// MX RR was invalid
        /// </summary>
        InvalidMXRecord,
        /// <summary>
        /// TXT RR was invalid
        /// </summary>
        InvalidTextRecord,
        /// <summary>
        /// SOA RR was invalid
        /// </summary>
        InvalidSOARecord,
        /// <summary>
        /// CNAME RR was invalid
        /// </summary>
        InvalidCNameRecord,
        /// <summary>
        /// CERT RR was invalid
        /// </summary>
        InvalidCertRecord,
        /// <summary>
        /// Invalid Request
        /// </summary>
        InvalidRequest,
        /// <summary>
        /// Invalid message header
        /// </summary>
        InvalidHeader,
        /// <summary>
        /// Invalid question in message
        /// </summary>
        InvalidQuestion,
        /// <summary>
        /// Invalid response message
        /// </summary>
        InvalidResponse
    }

    /// <summary>
    /// Represents program failures or expectation exceptions at the DNS protocol level.
    /// </summary>
    public class DnsProtocolException : DnsException
    {
        DnsProtocolError m_error;

        /// <summary>
        /// Intializes an exception with the specified <paramref name="error"/>
        /// </summary>
        /// <param name="error">The specific error subtype.</param>
        public DnsProtocolException(DnsProtocolError error)
        {
            m_error = error;
        }

        /// <summary>
        /// Intializes an exception with the specified <paramref name="error"/> and a reference to the underlying exception
        /// </summary>
        /// <param name="error">The specific error subtype.</param>
        /// <param name="inner">The exception that was the trigger for this one.</param>
        public DnsProtocolException(DnsProtocolError error, Exception inner)
            : base(inner)
        {
            m_error = error;
        }
        
        /// <summary>
        /// The error subtype.
        /// </summary>
        public DnsProtocolError Error
        {
            get
            {
                return m_error;
            }
        }

        /// <summary>
        /// Returns a string representation of this exception.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return string.Format("ERROR={0}\r\n{1}", m_error, base.ToString());
        }
    }
}
