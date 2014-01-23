using System;
using System.Collections.Generic;

namespace TCC2.API.CloudTracker
{
    public static class CloudTracker
    {
        #region DeleteCloudTrackerEPCEvents

        public static IAsyncResult BeginDeleteCloudTrackerEPCEvents(this Session session, string itemId, AsyncCallback callback, object state)
        {
            DeleteCloudTrackerEPCEvents deleteCloudTrackerEPCEvents = new DeleteCloudTrackerEPCEvents(session);
            deleteCloudTrackerEPCEvents.BeginCall(itemId, callback, state);
            return deleteCloudTrackerEPCEvents;
        }

        public static IAsyncResult BeginDeleteCloudTrackerEPCEvents(this Session session, IEnumerable<string> eventIds, AsyncCallback callback, object state)
        {
            DeleteCloudTrackerEPCEvents deleteCloudTrackerEPCEvents = new DeleteCloudTrackerEPCEvents(session);
            deleteCloudTrackerEPCEvents.BeginCall(eventIds, callback, state);
            return deleteCloudTrackerEPCEvents;
        }

        public static void EndDeleteCloudTrackerEPCEvents(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            ((DeleteCloudTrackerEPCEvents)ar).EndCall();
        }

        public static void DeleteCloudTrackerEPCEvents(this Session session, string itemId)
        {
            new DeleteCloudTrackerEPCEvents(session).Call(itemId);
        }

        public static void DeleteCloudTrackerEPCEvents(this Session session, IEnumerable<string> eventIds)
        {
            new DeleteCloudTrackerEPCEvents(session).Call(eventIds);
        }

        #endregion

        #region DeleteCloudTrackerItem

        public static IAsyncResult BeginDeleteCloudTrackerItem(this Session session, string itemId, AsyncCallback callback, object state)
        {
            DeleteCloudTrackerItem deleteCloudTrackerItem = new DeleteCloudTrackerItem(session);
            deleteCloudTrackerItem.BeginCall(itemId, callback, state);
            return deleteCloudTrackerItem;
        }

        public static void EndDeleteCloudTrackerItem(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            ((DeleteCloudTrackerItem)ar).EndCall();
        }

        public static void DeleteCloudTrackerItem(this Session session, string itemId)
        {
            new DeleteCloudTrackerItem(session).Call(itemId);
        }

        #endregion

        #region GetCloudTrackerEPCEvents

        public static IAsyncResult BeginGetCloudTrackerEPCEvents(this Session session, string itemId, PageableResponseParameters pageableParams, AsyncCallback callback, object state)
        {
            GetCloudTrackerEPCEvents getCloudTrackerEPCEvents = new GetCloudTrackerEPCEvents(session);
            getCloudTrackerEPCEvents.BeginCall(itemId, pageableParams, callback, state);
            return getCloudTrackerEPCEvents;
        }

        public static IAsyncResult BeginGetCloudTrackerEPCEvents(this Session session, string itemId, AsyncCallback callback, object state)
        {
            return session.BeginGetCloudTrackerEPCEvents(itemId, null, callback, state);
        }

        public static GetCloudTrackerEPCEventsResult EndGetCloudTrackerEPCEvents(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetCloudTrackerEPCEvents)ar).EndCall();
        }

        public static GetCloudTrackerEPCEventsResult GetCloudTrackerEPCEvents(this Session session, string itemId, PageableResponseParameters pageableParams)
        {
            return new GetCloudTrackerEPCEvents(session).Call(itemId, pageableParams);
        }

        public static GetCloudTrackerEPCEventsResult GetCloudTrackerEPCEvents(this Session session, string itemId)
        {
            return new GetCloudTrackerEPCEvents(session).Call(itemId, null);
        }

        #endregion

        #region GetCloudTrackerItem

        public static IAsyncResult BeginGetCloudTrackerItem(this Session session, string itemId, AsyncCallback callback, object state)
        {
            GetCloudTrackerItem getCloudTrackerItem = new GetCloudTrackerItem(session);
            getCloudTrackerItem.BeginCall(itemId, callback, state);
            return getCloudTrackerItem;
        }

        public static GetCloudTrackerItemResult EndGetCloudTrackerItem(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetCloudTrackerItem)ar).EndCall();
        }

        public static GetCloudTrackerItemResult GetCloudTrackerItem(this Session session, string itemId)
        {
            return new GetCloudTrackerItem(session).Call(itemId);
        }

        #endregion

        #region GetCloudTrackerItemFilters

        public static IAsyncResult BeginGetCloudTrackerItemFilters(this Session session, AsyncCallback callback, object state)
        {
            GetCloudTrackerItemFilters getCloudTrackerItemFilters = new GetCloudTrackerItemFilters(session);
            getCloudTrackerItemFilters.BeginCall(callback, state);
            return getCloudTrackerItemFilters;
        }

        public static GetCloudTrackerItemFiltersResult EndGetCloudTrackerItemFilters(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetCloudTrackerItemFilters)ar).EndCall();
        }

        public static GetCloudTrackerItemFiltersResult GetCloudTrackerItemFilters(this Session session)
        {
            return new GetCloudTrackerItemFilters(session).Call();
        }

        #endregion

        #region GetCloudTrackerItems

        public static IAsyncResult BeginGetCloudTrackerItems(this Session session, string orgId, IEnumerable<string> categories, IEnumerable<string> types, IEnumerable<string> locations, PageableResponseParameters pageableParams, DateTime? lastFilterTime, IEnumerable<CloudTrackerItemLastEventPair> itemLastEvents, AsyncCallback callback, object state)
        {
            GetCloudTrackerItems getCloudTrackerItems = new GetCloudTrackerItems(session);
            getCloudTrackerItems.BeginCall(orgId, categories, types, locations, pageableParams, lastFilterTime, itemLastEvents, callback, state);
            return getCloudTrackerItems;
        }

        public static IAsyncResult BeginGetCloudTrackerItems(this Session session, string orgId, IEnumerable<string> categories, IEnumerable<string> types, IEnumerable<string> locations, AsyncCallback callback, object state)
        {
            return session.BeginGetCloudTrackerItems(orgId, categories, types, locations, null, null, null, callback, state);
        }

        public static IAsyncResult BeginGetCloudTrackerItems(this Session session, AsyncCallback callback, object state)
        {
            return session.BeginGetCloudTrackerItems(null, null, null, null, null, null, null, callback, state);
        }

        public static GetCloudTrackerItemsResult EndGetCloudTrackerItems(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetCloudTrackerItems)ar).EndCall();
        }

        public static GetCloudTrackerItemsResult GetCloudTrackerItems(this Session session, string orgId, IEnumerable<string> categories, IEnumerable<string> types, IEnumerable<string> locations, PageableResponseParameters pageableParams, DateTime? lastFilterTime, IEnumerable<CloudTrackerItemLastEventPair> itemLastEvents)
        {
            return new GetCloudTrackerItems(session).Call(orgId, categories, types, locations, pageableParams, lastFilterTime, itemLastEvents);
        }

        public static GetCloudTrackerItemsResult GetCloudTrackerItems(this Session session, string orgId, IEnumerable<string> categories, IEnumerable<string> types, IEnumerable<string> locations)
        {
            return session.GetCloudTrackerItems(orgId, categories, types, locations, null, null, null);
        }

        public static GetCloudTrackerItemsResult GetCloudTrackerItems(this Session session)
        {
            return new GetCloudTrackerItems(session).Call(null, null, null, null, null, null, null);
        }

        #endregion

        #region GetCloudTrackerSettings

        public static IAsyncResult BeginGetCloudTrackerSettings(this Session session, string orgId, AsyncCallback callback, object state)
        {
            GetCloudTrackerSettings getCloudTrackerSettings = new GetCloudTrackerSettings(session);
            getCloudTrackerSettings.BeginCall(orgId, callback, state);
            return getCloudTrackerSettings;
        }

        public static GetCloudTrackerSettingsResult EndGetCloudTrackerSettings(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetCloudTrackerSettings)ar).EndCall();
        }

        public static GetCloudTrackerSettingsResult GetCloudTrackerSettings(this Session session, string orgId)
        {
            return new GetCloudTrackerSettings(session).Call(orgId);
        }

        #endregion

        #region SetCloudTrackerEPCEvents

        public static IAsyncResult BeginSetCloudTrackerEPCEvents(this Session session, IEnumerable<CloudTrackerEPCEventEntry> entries, AsyncCallback callback, object state)
        {
            SetCloudTrackerEPCEvents setCloudTrackerEPCEvents = new SetCloudTrackerEPCEvents(session);
            setCloudTrackerEPCEvents.BeginCall(entries, callback, state);
            return setCloudTrackerEPCEvents;
        }

        public static SetCloudTrackerEPCEventsResult EndSetCloudTrackerEPCEvents(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((SetCloudTrackerEPCEvents)ar).EndCall();
        }

        public static SetCloudTrackerEPCEventsResult SetCloudTrackerEPCEvents(this Session session, IEnumerable<CloudTrackerEPCEventEntry> entries)
        {
            return new SetCloudTrackerEPCEvents(session).Call(entries);
        }

        #endregion

        #region SetCloudTrackerItem

        public static IAsyncResult BeginSetCloudTrackerItem(this Session session, string itemId, string orgId, string activeEPC, string category, string type, string manufacturer, string model, string serialNumber, AsyncCallback callback, object state)
        {
            SetCloudTrackerItem setCloudTrackerItem = new SetCloudTrackerItem(session);
            setCloudTrackerItem.BeginCall(itemId, orgId, activeEPC, null, category, type, manufacturer, model, serialNumber, callback, state);
            return setCloudTrackerItem;
        }

        public static SetCloudTrackerItemResult EndSetCloudTrackerItem(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((SetCloudTrackerItem)ar).EndCall();
        }

        public static SetCloudTrackerItemResult SetCloudTrackerItem(this Session session, string itemId, string orgId, string activeEPC, string category, string type, string manufacturer, string model, string serialNumber)
        {
            return new SetCloudTrackerItem(session).Call(itemId, orgId, activeEPC, null, category, type, manufacturer, model, serialNumber);
        }

        #endregion

        #region SetCloudTrackerSettings

        public static IAsyncResult BeginSetCloudTrackerSettings(this Session session, string orgId, string viewGroup, string addEventGroup, string editGroup, AsyncCallback callback, object state)
        {
            SetCloudTrackerSettings setCloudTrackerSettings = new SetCloudTrackerSettings(session);
            setCloudTrackerSettings.BeginCall(orgId, viewGroup, addEventGroup, editGroup, callback, state);
            return setCloudTrackerSettings;
        }

        public static void EndSetCloudTrackerSettings(this Session session, IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            ((SetCloudTrackerSettings)ar).EndCall();
        }

        public static void SetCloudTrackerSettings(this Session session, string orgId, string viewGroup, string addEventGroup, string editGroup)
        {
            new SetCloudTrackerSettings(session).Call(orgId, viewGroup, addEventGroup, editGroup);
        }

        #endregion
    }
}