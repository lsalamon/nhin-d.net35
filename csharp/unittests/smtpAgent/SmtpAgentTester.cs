﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mime;
using NHINDirect.Mail;
using NHINDirect.Agent;
using NHINDirect.SmtpAgent;
using AgentTests;
using Xunit;
using Xunit.Extensions;

namespace SmtpAgentTests
{
    public class SmtpAgentTester
    {
        public const string TestMessage =
@"From: <toby@redmond.hsgincubator.com>
To: <biff@nhind.hsgincubator.com>, <bob@nhind.hsgincubator.com>
Subject: Simple Text Message
Date: Mon, 10 May 2010 14:53:27 -0700
MIME-Version: 1.0
Content-Type: text/plain

Yo. Wassup?";

        public const string CrossDomainMessage =
@"From: <toby@redmond.hsgincubator.com>
To: <biff@nhind.hsgincubator.com>, <bob@nhind.hsgincubator.com>, <gm2552@securehealthemail.com>
Subject: Simple Text Message
Date: Mon, 10 May 2010 14:53:27 -0700
MIME-Version: 1.0
Content-Type: text/plain

Yo. Wassup?";

        public const string BadMessage =
@"From: <toby@redmond.hsgincubator.com>
To: <xyz@untrusted.com>
Subject: Bad Text Message
Date: Mon, 10 May 2010 14:53:27 -0700
MIME-Version: 1.0
Content-Type: text/plain

Bad message?";

        public const string UnknownUsersMessage =
@"From: <toby@redmond.hsgincubator.com>
To: <frank@nhind.hsgincubator.com>, <joe@nhind.hsgincubator.com>
Subject: Unknown Users Text Message
Date: Mon, 10 May 2010 14:53:27 -0700
MIME-Version: 1.0
Content-Type: text/plain

Yo. Wassup?";
        
        internal string MakeFilePath(string subPath)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), subPath);
        }
        
        internal CDO.Message LoadMessage(string text)
        {
            return NHINDirect.SmtpAgent.Extensions.LoadCDOMessageFromText(text);
        }
        
        internal CDO.Message LoadMessage(CDO.Message source)
        {
            return this.LoadMessage(source.GetMessageText());
        }
        
        internal void VerifyOutgoingMessage(CDO.Message message)
        {
            Assert.True(string.IsNullOrEmpty(message.Subject));
         
            ContentType contentType = new ContentType(message.GetContentType());
            Assert.True(NHINDirect.Cryptography.SMIMEStandard.IsContentEncrypted(contentType));
        }
        
        internal void VerifyIncomingMessage(CDO.Message message)
        {
            ContentType contentType = new ContentType(message.GetContentType());
            Assert.False(NHINDirect.Cryptography.SMIMEStandard.IsContentEncrypted(contentType));
        }

        internal void ProcessEndToEnd(SmtpAgent agent, Message msg, out OutgoingMessage outgoing, out IncomingMessage incoming)
        {
            outgoing = (OutgoingMessage) agent.SecurityAgent.ProcessOutgoing(new MessageEnvelope(msg));
            incoming = (IncomingMessage) agent.SecurityAgent.ProcessIncoming(new MessageEnvelope(outgoing.SerializeMessage()));
        }
    }
}