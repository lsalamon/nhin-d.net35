﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Health.Direct.Admin.Console.Models.SrvRecordModel>" %>

<div id="dnsrecord-details">
    <span class="display-label"><%= Html.LabelFor(model => model.DomainName) %></span>
    <span class="display-field">
        <%= Html.DisplayTextFor(model => model.DomainName) %>
    </span>
    <br class="clear" />
            
    <span class="display-label"><%= Html.LabelFor(model => model.Weight)%></span>
    <span class="display-field">
        <%= Html.DisplayTextFor(model => model.Weight)%>
    </span>
    <br class="clear" />
            
    <span class="display-label"><%= Html.LabelFor(model => model.Port)%></span>
    <span class="display-field">
        <%= Html.DisplayTextFor(model => model.Port)%>
    </span>
    <br class="clear" />
    
    <span class="display-label"><%= Html.LabelFor(model => model.Target)%></span>
    <span class="display-field">
        <%= Html.DisplayTextFor(model => model.Target)%>
    </span>
    <br class="clear" />
            
    <span class="display-label"><%= Html.LabelFor(model => model.Priority)%></span>
    <span class="display-field">
        <%= Html.DisplayTextFor(model => model.Priority)%>
    </span>
    <br class="clear" />
            
    <span class="display-label"><%= Html.LabelFor(model => model.TTL)%></span>
    <span class="display-field">
        <%= Html.DisplayTextFor(model => model.TTL)%>
    </span>
    <br class="clear" />
        
    <span class="display-label"><%= Html.LabelFor(model => model.Notes) %></span>
    <span class="display-field">
        <%= Html.DisplayTextFor(model => model.Notes)%>
    </span>
    <br class="clear" />
            
</div>