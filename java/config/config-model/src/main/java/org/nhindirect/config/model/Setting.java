/* 
Copyright (c) 2010, NHIN Direct Project
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer 
   in the documentation and/or other materials provided with the distribution.  
3. Neither the name of the The NHIN Direct Project (nhindirect.org) nor the names of its contributors may be used to endorse or promote 
   products derived from this software without specific prior written permission.
   
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS 
BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
THE POSSIBILITY OF SUCH DAMAGE.
 */

package org.nhindirect.config.model;

import java.util.Calendar;

import org.codehaus.enunciate.json.JsonRootType;

/**
 * Name value pair settings in the sytem.
 * @author Greg Meyer
 * @since 1.0
 */
///CLOVER:OFF
@JsonRootType
public class Setting 
{
    private String name;
    private String value;
    private long id;
    private Calendar createTime;
    private Calendar updateTime;
    private EntityStatus status;
	
    /**
     * Empty constructor
     */
	public Setting()
	{
		
	}

	/**
	 * Gets the name of the setting.
	 * @return The name of the setting.
	 */
	public String getName() 
	{
		return name;
	}

	/**
	 * Sets the name of the setting.
	 * @param name The name of the setting.
	 */
	public void setName(String name) 
	{
		this.name = name;
	}

	/**
	 * Gets the value of the setting.
	 * @return The value of the setting.
	 */
	public String getValue() 
	{
		return value;
	}

	/**
	 * Sets the value of the setting.
	 * @param value The value of the setting.
	 */
	public void setValue(String value) 
	{
		this.value = value;
	}

	/**
	 * Gets the internal system id of the setting.
	 * @return The internal system id of the setting.
	 */
	public long getId() 
	{
		return id;
	}

	/**
	 * Sets the internal system id of the setting.
	 * @param id The internal system id of the setting.
	 */
	public void setId(long id)
	{
		this.id = id;
	}

	/**
	 * Sets the date/time the setting was created in the system.
	 * @param createTime The date/time the setting was created in the system.
	 */ 
	public Calendar getCreateTime() 
	{
		return createTime;
	}

	/**
	 * Sets the date/time the setting was created in the system.
	 * @param createTime The date/time the setting was created in the system.
	 */
	public void setCreateTime(Calendar createTime) 
	{
		this.createTime = createTime;
	}

	/**
	 * Gets the date/time that the setting was last updated.
	 * @return The date/time that the setting was last updated.
	 */
	public Calendar getUpdateTime() 
	{
		return updateTime;
	}

	/**
	 * Sets the date/time that the setting was last updated.
	 * @param updateTime The date/time that the setting was last updated.
	 */
	public void setUpdateTime(Calendar updateTime) 
	{
		this.updateTime = updateTime;
	}

	/**
	 * Gets the status of the setting.
	 * @return The status of the setting.
	 */
	public EntityStatus getStatus() 
	{
		return status;
	}

	/**
	 * Sets the status of the setting.
	 * @param status The status of the setting.
	 */
	public void setStatus(EntityStatus status) 
	{
		this.status = status;
	}
	
	
}
///CLOVER:ON
