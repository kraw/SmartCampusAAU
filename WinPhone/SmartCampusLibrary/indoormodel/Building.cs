﻿/*
Copyright (c) 2014, Aalborg University
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the <organization> nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL AAlBORG UNIVERSITY BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.smartcampus.indoormodel.graph;

namespace com.smartcampus.indoormodel
{
    public class Building
    {
        public static int getCurrentFloor()
        {
            return Building.mCurrentFloor;
        }
        public static void setCurrentFloor(int value)
        {
            mCurrentFloor = value;
        }
        private int mBuildingID;
        //The building's name
        private String mName;
        //Url to an IFC model (if one exists)
        private String mIfcUrl;
        //Address of building (for geocoding)
        private double mLatitude;
        private double mLongitude;
        private String mCountry;
        private String mPostalCode;

        private String mMaxAddress;
        private String mUrl;
        //Urls to graphical building maps (one for each floor).  
        private Dictionary<int, String> mMapUrls = new Dictionary<int, String>();

        //A list of APs that can be heard in the building
        private List<String> mPermissableAPs = new List<String>();
        private int mStories; //number of stories in the building

        private static int mCurrentFloor;

        private Dictionary<int, Building_Floor> mFloors = new Dictionary<int, Building_Floor>();
        private IGraph mGraphModel = new DictionaryGraph(); //vs Graph

        private static Building instance;
        public static Building getActiveBuilding()
        {
            if (instance == null)
            {
                instance = new Building();
            }

            return instance;
        }

        /**
         * 
         * @param newFloor
         * @return True, if the floor was added (i.e., it had a new floor number); false otherwise
         */
        public bool addFloor(Building_Floor newFloor)
        {
            if (!mFloors.ContainsKey(newFloor.getFloorNumber()))
            {
                mFloors.Add(newFloor.getFloorNumber(), newFloor);
                return true;
            }
            return false;
        }
        public void addMapUrl(int story, String mapUrl)
        {
            mStories++;
            if (!mMapUrls.ContainsKey(story))
                mMapUrls.Add(story, mapUrl);
        }

        public int getBuildingID()
        {
            return mBuildingID;
        }
        /**
         * @return the mCountry
         */
        public String getCountry()
        {
            return mCountry;
        }

        public Building_Floor getFloorAtFloorNumber(int floorNumber)
        {
            return mFloors[floorNumber];
        }
        public IEnumerable<Building_Floor> getFloors()
        {
            return mFloors.Values;
        }

        public IGraph getGraphModel()
        {
            return mGraphModel;
        }

        public String getIfcUrl()
        {
            return mIfcUrl;
        }

        /**
         * @return The smallest of the available floors
         */
        public int getInitialFloorNumber() {
    	int min = int.MaxValue;
    	foreach (int i in mFloors.Keys)
    	{
    		if (i < min)
    			min = i;
    	}
    	return min;
    }

        /**
         * @return the mLatitude
         */
        public double getLatitude()
        {
            return mLatitude;
        }

        /**
         * @return the mLongitude
         */
        public double getLongitude()
        {
            return mLongitude;
        }

        public String getMapUrl(int story)
        {
            return mMapUrls[story];
        }
        public Dictionary<int, String> getMapUrls()
        {
            return mMapUrls;
        }

        /**
         * @return the mMaxAddress
         */
        public String getMaxAddress()
        {
            return mMaxAddress;
        }
        public String getName()
        {
            return mName;
        }

        public String GetName()
        {
            return mName;
        }

        public int getNumberOfFloors()
        {
            return mFloors.Count;
        }

        public List<String> getPermissableAPs()
        {
            return mPermissableAPs;
        }

        /**
         * @return the mPostalCode
         */
        public String getPostalCode()
        {
            return mPostalCode;
        }

        public int getStories()
        {
            return mStories;
        }

        /**
         * @return the mUrl
         */
        public String getUrl()
        {
            return mUrl;
        }
        public bool hasFloorAt(int floorNum)
        {
            return mFloors[floorNum] != null;
        }

        public bool hasFloors()
        {
            return mFloors.Count > 0;
        }

        public bool hasMapUrl(int story)
        {
            return mMapUrls.ContainsKey(story);
        }

        public Building_Floor removeFloorAtFloorNumber(int floorNumber)
        {
            Building_Floor tbr = mFloors[floorNumber];

            mFloors.Remove(floorNumber);

            return tbr;
        }

        public void setBuildingID(int value)
        {
            mBuildingID = value;
        }

        /**
         * @param mCountry the mCountry to set
         */
        public void setCountry(String mCountry)
        {
            this.mCountry = mCountry;
        }

        public void setGraphModel(IGraph value)
        {
            mGraphModel = value;
        }

        public void setIfcUrl(String value)
        {
            mIfcUrl = value;
        }

        /**
         * @param mLatitude the mLatitude to set
         */
        public void setLatitude(double mLatitude)
        {
            this.mLatitude = mLatitude;
        }

        /**
         * @param mLongitude the mLongitude to set
         */
        public void setLongitude(double mLongitude)
        {
            this.mLongitude = mLongitude;
        }

        public void setMapUrls(Dictionary<int, String> value)
        {
            mMapUrls = value;
        }

        /**
         * @param mMaxAddress the mMaxAddress to set
         */
        public void setMaxAddress(String mMaxAddress)
        {
            this.mMaxAddress = mMaxAddress;
        }

        public void setName(String name)
        {
            this.mName = name;
        }

        public void SetName(String value)
        {
            mName = value;
        }

        public void setPermissableAPs(List<String> value)
        {
            mPermissableAPs = value;
        }

        /**
         * @param mPostalCode the mPostalCode to set
         */
        public void setPostalCode(String mPostalCode)
        {
            this.mPostalCode = mPostalCode;
        }

        public void setStories(int value)
        {
            mStories = value;
        }

        /**
         * @param mUrl the mUrl to set
         */
        public void setUrl(String mUrl)
        {
            this.mUrl = mUrl;
        }
    }
}
