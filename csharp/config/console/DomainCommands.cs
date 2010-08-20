﻿/* 
 Copyright (c) 2010, NHIN Direct Project
 All rights reserved.

 Authors:
    Umesh Madan     umeshma@microsoft.com
  
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
using System.Net.Mail;
using NHINDirect.Tools.Command;
using NHINDirect.Config.Store;
using NHINDirect.Config.Client.DomainManager;

namespace NHINDirect.Config.Command
{
    public class DomainCommands
    {
        DomainManagerClient m_client;
        AddressManagerClient m_addressClient;
        
        public DomainCommands()
        {
            m_client = new DomainManagerClient();
            m_addressClient = new AddressManagerClient();
        }     
        
        public void Command_DomainAdd(string[] args)
        {            
            Domain domain = new Domain(args.GetRequiredValue(0));
            domain.Status = args.GetOptionalEnum<EntityStatus>(1, EntityStatus.New);
            
            m_client.AddDomain(domain);
        }                   
        public void Usage_DomainAdd()
        {
            Console.WriteLine("Add a new domain.");
            Console.WriteLine("    domainAdd domainName [status]");            
        }
        
        public void Command_DomainGet(string[] args)
        {
            string name = args.GetRequiredValue(0);
            Print(this.DomainGet(name));
        }
        public void Usage_DomainGet()
        {
            Console.WriteLine("Retrieve information for an existing domain.");
            Console.WriteLine("    domainGet domainName");
        }
        
        public void Command_DomainStatusSet(string[] args)
        {
            string name = args.GetRequiredValue(0);
            EntityStatus status = args.GetRequiredEnum<EntityStatus>(1);
            
            Domain domain = this.DomainGet(name);
            domain.Status = status;
            m_client.UpdateDomain(domain);
        }
        public void Usage_DomainStatusSet()
        {
            Console.WriteLine("Change a domain's status");
            Console.WriteLine("    domainstatusset domainName Status(New | Enabled | Disabled)");
        }
        
        public void Command_DomainGetPostmaster(string[] args)
        {
            string name = args.GetRequiredValue(0);
            Domain domain = DomainGet(name);
            Address address = m_addressClient.GetAddress(domain.ID);
            AddressCommands.Print(address);
        }
        public void Usage_DomainGetPostmaster()
        {
            Console.WriteLine("Display a domain's postmaster, if set explicitly.");
            Console.WriteLine("    domaingetpostmaster domainName");
        }
        public void Command_DomainSetPostmaster(string[] args)
        {
            MailAddress email = new MailAddress(args.GetRequiredValue(0));
            
            Address postmaster = m_addressClient.GetAddress(email);
            if (postmaster == null)
            {
                throw new ArgumentException(string.Format("Postmaster address {0} not found", email));
            }
            
            Domain domain = this.DomainGet(email.Host);
            domain.PostmasterID = postmaster.ID;
            m_client.UpdateDomain(domain);
        }        
        public void Usage_DomainSetPostmaster()
        {
            Console.WriteLine("Set the postmaster address for a domain. The address must have been already created.");
            Console.WriteLine("    domainsetpostmaster postmasterEmail");
        }
        
        public void Command_DomainRemove(string[] args)
        {
            m_client.RemoveDomain(args.GetRequiredValue(0));
        }
        public void Usage_DomainRemove()
        {
            Console.WriteLine("Remove a domain.");
            Console.WriteLine("    domainremove domainName");
        }
        
        public void Command_DomainListAll(string[] args)
        {
            int chunkSize = args.GetOptionalValue<int>(0, 25);            
            Print(m_client.EnumerateDomains(chunkSize));
        }

        Domain DomainGet(string name)
        {
            return DomainGet(m_client, name);
        }

        internal static Domain DomainGet(DomainManagerClient client, string name)
        {
            Domain domain = client.GetDomain(name);
            if (domain == null)
            {
                throw new ArgumentException(string.Format("Domain {0} not found", name));
            }

            return domain;
        }
        
        public static void Print(IEnumerable<Domain> domains)
        {
            foreach(Domain domain in domains)
            {
                Print(domain);
                CommandUI.PrintSectionBreak();
            }
        }
        
        public static void Print(Domain domain)
        {
            CommandUI.Print("Name", domain.Name);
            CommandUI.Print("ID", domain.ID);
            CommandUI.Print("CreateDate", domain.CreateDate);
            CommandUI.Print("UpdateDate", domain.UpdateDate);
            CommandUI.Print("PostmasterID", domain.PostmasterID);
            CommandUI.Print("Status", domain.Status);
        }
    }
}