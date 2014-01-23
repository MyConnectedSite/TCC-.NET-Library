using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TCC2.API.Filesystem
{
    public static class FilesystemApi
    {
        #region MkDir

        public static IAsyncResult BeginMkDir(this Session session, string filespaceId, IEnumerable<string> paths, bool force, bool hidden, string clientType, AsyncCallback callback, object state)
        {
            MkDir mkDir = new MkDir(session);
            mkDir.BeginCall(filespaceId, paths, force, hidden, clientType, callback, state);
            return mkDir;
        }

        public static IAsyncResult BeginMkDir(this Session session, string filespaceId, IEnumerable<string> path, AsyncCallback callback, object state)
        {
            return BeginMkDir(session, filespaceId, path, false, false, null, callback, state);
        }

        public static MkDirResult EndMkDir(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((MkDir)ar).EndCall();
        }

        public static MkDirResult MkDir(this Session session, string filespaceId, IEnumerable<string> paths, bool force, bool hidden, string clientType)
        {
            return new MkDir(session).Call(filespaceId, paths, force, hidden, clientType);
        }

        public static MkDirResult MkDir(this Session session, string filespaceId, IEnumerable<string> paths)
        {
            return MkDir(session, filespaceId, paths, false, false, null);
        }

        public static MkDirResult MkDir(this Session session, string filespaceId, bool force, bool hidden, string clientType, params string[] paths)
        {
            return session.MkDir(filespaceId, paths, force, hidden, clientType); 
        }

        public static MkDirResult MkDir(this Session session, string filespaceId, params string[] paths)
        {
            return session.MkDir(filespaceId, paths.AsEnumerable());
        }

        public static MkDirResult MkDirIfNotExist(this Session session, string filespaceId, string path)
        {
            return session.MkDirIfNotExist(filespaceId, false, path);
        }

        public static MkDirResult MkDirIfNotExist(this Session session, string filespaceId, bool hidden, string path)
        {
            return MkDirIfNotExist(session, filespaceId, false, hidden, path);
        }

        public static MkDirResult MkDirIfNotExist(this Session session, string filespaceId, bool force, bool hidden, string path)
        {
            try
            {
                return session.MkDir(filespaceId, force, hidden, null, path);
            }
            catch (TccException ex)
            {
                if (ex.ErrorId != "FOLDER_ALREADY_EXIST")
                    throw;

                return null;
            }
        }

        #endregion

        #region GetFilespace

        public static IAsyncResult BeginGetFilespace(this Session session, string filespaceId, AsyncCallback callback, object state)
        {
            GetFilespace getFilespace = new GetFilespace(session);
            getFilespace.BeginCall(filespaceId, callback, state);
            return getFilespace;
        }

        public static GetFilespaceResult EndGetFilespace(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetFilespace)ar).EndCall();
        }

        public static IAsyncResult BeginGetFilespace(this Session session, string filespaceShortName, string orgShortName, AsyncCallback callback, object state)
        {
            GetFilespace getFilespace = new GetFilespace(session);
            getFilespace.BeginCall(filespaceShortName, orgShortName, callback, state);
            return getFilespace;
        }

        public static GetFilespaceResult GetFilespace(this Session session, string filespaceShortName, string orgShortName)
        {
            return new GetFilespace(session).Call(filespaceShortName, orgShortName);
        }

        public static GetFilespaceResult GetFilespace(this Session session, string filespaceId)
        {
            return new GetFilespace(session).Call(filespaceId);
        }

        #endregion

        #region SetFilespace

        public static IAsyncResult BeginSetFilespace(this Session session, string orgId, string filespaceId, string shortName, string title, string description, string filespaceType, int? deletedFilesMaximumAge, bool? mailInEnabled, IEnumerable<string> acceptableSenders, int? maxVersionAge, int? maxVersionCount, AccessControlList<AccessControlEntry> acl, AsyncCallback callback, object state)
        {
            SetFilespace setFilespace = new SetFilespace(session);
            setFilespace.BeginCall(orgId, filespaceId, shortName, title, description, filespaceType, deletedFilesMaximumAge, mailInEnabled, acceptableSenders, maxVersionAge, maxVersionCount, acl, callback, state);
            return setFilespace;
        }

        public static IAsyncResult BeginSetFilespace(this Session session, string orgId, string filespaceId, string shortName, string title, AsyncCallback callback, object state)
        {
            return session.BeginSetFilespace(orgId, filespaceId, shortName, title, null, null, null, null, null, null, null, null, callback, state);
        }

        public static SetFilespaceResult EndSetFilespace(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((SetFilespace)ar).EndCall();
        }

        public static SetFilespaceResult SetFilespace(this Session session, string orgId, string filespaceId, string shortName, string title, string description, string filespaceType, int? deletedFilesMaximumAge, bool? mailInEnabled, IEnumerable<string> acceptableSenders, int? maxVersionAge, int? maxVersionCount, AccessControlList<AccessControlEntry> acl)
        {
            return new SetFilespace(session).Call(orgId, filespaceId, shortName, title, description, filespaceType, deletedFilesMaximumAge, mailInEnabled, acceptableSenders, maxVersionAge, maxVersionCount, acl);
        }

        public static SetFilespaceResult SetFilespace(this Session session, string orgId, string filespaceId, string shortName, string title, string description, string filespaceType)
        {
            return new SetFilespace(session).Call(orgId, filespaceId, shortName, title, description, filespaceType);
        }

        #endregion

        #region GetFilespaces

        public static IAsyncResult BeginGetFilespaces(this Session session, string filespaceType, string orgIdFilter, FilespacesFilter? filter, bool? showAnonymous, AsyncCallback callback, object state)
        {
            GetFilespaces getFilespaces = new GetFilespaces(session);
            getFilespaces.BeginCall(filespaceType, orgIdFilter, filter, showAnonymous, callback, state);
            return getFilespaces;
        }

        public static IAsyncResult BeginGetFilespaces(this Session session, string filespaceType, string orgIdFilter, AsyncCallback callback, object state)
        {
            return session.BeginGetFilespaces(filespaceType, orgIdFilter, null, null, callback, state);
        }

        public static GetFilespacesResult EndGetFilespaces(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((GetFilespaces)ar).EndCall();
        }

        public static GetFilespacesResult GetFilespaces(this Session session, string filespaceType, string orgIdFilter, FilespacesFilter? filter, bool? showAnonymous)
        {
            return new GetFilespaces(session).Call(filespaceType, orgIdFilter, filter, showAnonymous);
        }

        public static GetFilespacesResult GetFilespaces(this Session session)
        {
            return new GetFilespaces(session).Call(null, null, null, null);
        }

        #endregion

        #region DeleteFilespace

        public static IAsyncResult BeginDeleteFilespace(this Session session, string filespaceId, AsyncCallback callback, object state)
        {
            DeleteFilespace deleteFilespace = new DeleteFilespace(session);
            deleteFilespace.BeginCall(filespaceId, callback, state);
            return deleteFilespace;
        }

        public static void EndDeleteFilespace(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((DeleteFilespace)ar).EndCall();
        }

        public static void DeleteFilespace(this Session session, string filespaceId)
        {
            new DeleteFilespace(session).Call(filespaceId);
        }

        #endregion

        #region UpdateDateTime

        public static IAsyncResult BeginUpdateDateTime(this Session session, string filespaceId, string path, DateTime? createTime, DateTime? modifyTime, AsyncCallback callback, object state)
        {
            UpdateDateTime updateDateTime = new UpdateDateTime(session);
            updateDateTime.BeginCall(filespaceId, path, createTime, modifyTime, callback, state);
            return updateDateTime;
        }

        public static void EndUpdateDateTime(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((UpdateDateTime)ar).EndCall();
        }

        public static void UpdateDateTime(this Session session, string filespaceId, string path, DateTime? createTime, DateTime? modifyTime)
        {
            new UpdateDateTime(session).Call(filespaceId, path, createTime, modifyTime);
        }

        #endregion

        #region Dir

        public static IAsyncResult BeginDir(this Session session, string filespaceId, string path, bool recursive, IEnumerable<string> fileMaskList, FileMaskRelation? fileMaskRelation, bool? filterFolders, bool wantAspects, bool wantHidden, AsyncCallback callback, object state)
        {
            Dir dir = new Dir(session);
            dir.BeginCall(filespaceId, path, recursive, fileMaskList, fileMaskRelation, filterFolders, wantAspects, wantHidden, callback, state);
            return dir;
        }

        public static IAsyncResult BeginDir(this Session session, string filespaceId, string path, bool recursive, AsyncCallback callback, object state)
        {
            return BeginDir(session, filespaceId, path, recursive, null, null, false, false, false, callback, state);
        }

        public static DirResult EndDir(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((Dir)ar).EndCall();
        }

        public static DirResult Dir(this Session session, string filespaceId, string path, bool recursive, IEnumerable<string> fileMaskList, FileMaskRelation? fileMaskRelation, bool? filterFolders, bool wantAspects, bool wantHidden)
        {
            return new Dir(session).Call(filespaceId, path, recursive, fileMaskList, fileMaskRelation, filterFolders, wantAspects, wantHidden);
        }

        public static DirResult Dir(this Session session, string filespaceId, string path, bool recursive)
        {
            return new Dir(session).Call(filespaceId, path, recursive, null, null, null, false, false);
        }

        #endregion

        #region CheckOut

        public static IAsyncResult BeginCheckOut(this Session session, string filespaceId, string path, string clientType, string comment, AsyncCallback callback, object state)
        {
            CheckOut checkOut = new CheckOut(session);
            checkOut.BeginCall(filespaceId, path, clientType, comment, callback, state);
            return checkOut;
        }

        public static IAsyncResult BeginCheckOut(this Session session, string filespaceId, string path, AsyncCallback callback, object state)
        {
            return BeginCheckOut(session, filespaceId, path, null, null, callback, state);
        }

        public static void EndCheckOut(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((CheckOut)ar).EndCall();
        }

        public static void CheckOut(this Session session, string filespaceId, string path, string clientType, string comment)
        {
            new CheckOut(session).Call(filespaceId, path, clientType, comment);
        }

        public static void CheckOut(this Session session, string filespaceId, string path)
        {
            new CheckOut(session).Call(filespaceId, path, null);
        }

        #endregion

        #region CheckIn

        public static IAsyncResult BeginCheckIn(this Session session, string filespaceId, string path, string clientType, AsyncCallback callback, object state)
        {
            CheckIn checkIn = new CheckIn(session);
            checkIn.BeginCall(filespaceId, path, clientType, callback, state);
            return checkIn;
        }

        public static IAsyncResult BeginCheckIn(this Session session, string filespaceId, string path, AsyncCallback callback, object state)
        {
            return BeginCheckIn(session, filespaceId, path, null, callback, state);
        }

        public static void EndCheckIn(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((CheckIn)ar).EndCall();
        }

        public static void CheckIn(this Session session, string filespaceId, string path, string clientType)
        {
            new CheckIn(session).Call(filespaceId, path, clientType);
        }

        public static void CheckIn(this Session session, string filespaceId, string path)
        {
            new CheckIn(session).Call(filespaceId, path, null);
        }

        #endregion

        #region CancelCheckOut

        public static IAsyncResult BeginCancelCheckOut(this Session session, string filespaceId, string path, string clientType, AsyncCallback callback, object state)
        {
            CancelCheckOut cancelCheckOut = new CancelCheckOut(session);
            cancelCheckOut.BeginCall(filespaceId, path, clientType, callback, state);
            return cancelCheckOut;
        }

        public static IAsyncResult BeginCancelCheckOut(this Session session, string filespaceId, string path, AsyncCallback callback, object state)
        {
            return BeginCancelCheckOut(session, filespaceId, path, null, callback, state);
        }

        public static void EndCancelCheckOut(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((CancelCheckOut)ar).EndCall();
        }

        public static void CancelCheckOut(this Session session, string filespaceId, string path, string clientType)
        {
            new CancelCheckOut(session).Call(filespaceId, path, clientType);
        }

        public static void CancelCheckOut(this Session session, string filespaceId, string path)
        {
            new CancelCheckOut(session).Call(filespaceId, path, null);
        }

        #endregion

        #region Del

        public static IAsyncResult BeginDel(this Session session, string filespaceId, string path, string clientType, AsyncCallback callback, object state)
        {
            Del del = new Del(session);
            del.BeginCall(filespaceId, path, clientType, callback, state);
            return del;
        }

        public static IAsyncResult BeginDel(this Session session, string filespaceId, string path, AsyncCallback callback, object state)
        {
            return BeginDel(session, filespaceId, path, null, callback, state);
        }

        public static void EndDel(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((Del)ar).EndCall();
        }

        public static void Del(this Session session, string filespaceId, string path, string clientType)
        {
            new Del(session).Call(filespaceId, path, clientType);
        }

        public static void Del(this Session session, string filespaceId, string path)
        {
            new Del(session).Call(filespaceId, path, null);
        }

        #endregion

        #region GetFile

        public static IAsyncResult BeginGetFile(this Session session, Stream result, string filespaceId, string path, bool closeResultStream, DateTime? versionTime, string mimeType, bool? noAttachment, AsyncCallback callback, object state)
        {
            GetFile getFile = new GetFile(session);
            getFile.BeginCall(result, filespaceId, path, closeResultStream, versionTime, mimeType, noAttachment, callback, state);
            return getFile;
        }

        public static IAsyncResult BeginGetFile(this Session session, Stream result, string filespaceId, string path, bool closeResultStream, AsyncCallback callback, object state)
        {
            return BeginGetFile(session, result, filespaceId, path, closeResultStream, null, null, null, callback, state);
        }

        public static IAsyncResult BeginGetFile(this Session session, string fileName, string filespaceId, string path, DateTime? versionTime, string mimeType, bool? noAttachment, AsyncCallback callback, object state)
        {
            GetFile getFile = new GetFile(session);
            getFile.BeginCall(fileName, filespaceId, path, versionTime, mimeType, noAttachment, callback, state);
            return getFile;
        }

        public static IAsyncResult BeginGetFile(this Session session, string fileName, string filespaceId, string path, AsyncCallback callback, object state)
        {
            return BeginGetFile(session, fileName, filespaceId, path, null, null, null, callback, state);
        }

        public static void EndGetFile(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((GetFile)ar).EndCall();
        }

        public static void GetFile(this Session session, Stream result, string filespaceId, string path, bool closeResultStream, DateTime? versionTime, string mimeType, bool? noAttachment)
        {
            new GetFile(session).Call(result, filespaceId, path, closeResultStream, versionTime, mimeType, noAttachment);
        }

        public static void GetFile(this Session session, Stream result, string filespaceId, string path, bool closeResultStream)
        {
            new GetFile(session).Call(result, filespaceId, path, closeResultStream, null, null, null);
        }

        public static void GetFile(this Session session, string fileName, string filespaceId, string path, DateTime? versionTime, string mimeType, bool? noAttachment)
        {
            new GetFile(session).Call(fileName, filespaceId, path, versionTime, mimeType, noAttachment);
        }

        public static void GetFile(this Session session, string fileName, string filespaceId, string path)
        {
            new GetFile(session).Call(fileName, filespaceId, path, null, null, null);
        }

        #endregion

        #region PutFile

        public static IAsyncResult BeginPutFile(this Session session, PutFileItem file, string deleteCookie, string clientType, AsyncCallback callback, object state)
        {
            PutFile putFile = new PutFile(session);
            putFile.BeginCall(file, deleteCookie, clientType, callback, state);
            return putFile;
        }

        public static IAsyncResult BeginPutFile(this Session session, PutFileItem file, AsyncCallback callback, object state)
        {
            return session.BeginPutFile(file, null, null, callback, state);
        }

        public static IAsyncResult BeginPutFile(this Session session, IEnumerable<PutFileItem> files, string deleteCookie, string clientType, AsyncCallback callback, object state)
        {
            PutFile putFile = new PutFile(session);
            putFile.BeginCall(files, deleteCookie, clientType, callback, state);
            return putFile;
        }

        public static IAsyncResult BeginPutFile(this Session session, IEnumerable<PutFileItem> files, AsyncCallback callback, object state)
        {
            return session.BeginPutFile(files, null, null, callback, state);
        }

        public static PutFileResult EndPutFile(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((PutFile)ar).EndCall();
        }

        public static PutFileResult PutFile(this Session session, PutFileItem file, string deleteCookie, string clientType)
        {
            return new PutFile(session).Call(file, deleteCookie, clientType);
        }

        public static PutFileResult PutFile(this Session session, PutFileItem file)
        {
            return new PutFile(session).Call(file, null, null);
        }

        public static PutFileResult PutFile(this Session session, IEnumerable<PutFileItem> files, string deleteCookie, string clientType)
        {
            return new PutFile(session).Call(files, deleteCookie, clientType);
        }

        public static PutFileResult PutFile(this Session session, IEnumerable<PutFileItem> files)
        {
            return new PutFile(session).Call(files, null, null);
        }

        #endregion

        #region Files Download Handler

        public static IAsyncResult BeginDownloadFile(this Session session, Stream result, string orgShortName, string filespaceShortName, string path, bool closeResultStream, bool? noAttachment, AsyncCallback callback, object state)
        {
            Files downloadFile = new Files(session);
            downloadFile.BeginCall(result, orgShortName, filespaceShortName, path, closeResultStream, noAttachment, callback, state);
            return downloadFile;
        }

        public static IAsyncResult BeginDownloadFile(this Session session, string fileName, string orgShortName, string filespaceShortName, string path, bool? noAttachment, AsyncCallback callback, object state)
        {
            Files downloadFile = new Files(session);
            downloadFile.BeginCall(fileName, orgShortName, filespaceShortName, path, noAttachment, callback, state);
            return downloadFile;
        }

        public static IAsyncResult BeginDownloadFile(this Session session, Stream result, string filespaceId, string path, bool closeResultStream, bool? noAttachment, AsyncCallback callback, object state)
        {
            Files downloadFile = new Files(session);
            downloadFile.BeginCall(result, filespaceId, path, closeResultStream, noAttachment, callback, state);
            return downloadFile;
        }

        public static IAsyncResult BeginDownloadFile(this Session session, string fileName, string filespaceId, string path, bool? noAttachment, AsyncCallback callback, object state)
        {
            Files downloadFile = new Files(session);
            downloadFile.BeginCall(fileName, filespaceId, path, noAttachment, callback, state);
            return downloadFile;
        }

        public static void EndDownloadFile(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((Files)ar).EndCall();
        }

        public static void DownloadFile(this Session session, Stream result, string orgShortName, string filespaceShortName, string path, bool closeResultStream, bool? noAttachment)
        {
            new Files(session).Call(result, orgShortName, filespaceShortName, path, closeResultStream, noAttachment);
        }

        public static void DownloadFile(this Session session, string fileName, string orgShortName, string filespaceShortName, string path, bool? noAttachment)
        {
            new Files(session).Call(fileName, orgShortName, filespaceShortName, path, noAttachment);
        }

        public static void DownloadFile(this Session session, Stream result, string filespaceId, string path, bool closeResultStream, bool? noAttachment)
        {
            new Files(session).Call(result, filespaceId, path, closeResultStream, noAttachment);
        }

        public static void DownloadFile(this Session session, string fileName, string filespaceId, string path, bool? noAttachment)
        {
            new Files(session).Call(fileName, filespaceId, path, noAttachment);
        }

        #endregion

        #region Copy

        public static IAsyncResult BeginCopy(this Session session, string filespaceId, string path, string newFilespaceId, string newPath, bool replace, bool? merge, DateTime? versionTime, AsyncCallback callback, object state)
        {
            Copy downloadFile = new Copy(session);
            downloadFile.BeginCall(filespaceId, path, newFilespaceId, newPath, replace, merge, versionTime, callback, state);
            return downloadFile;
        }

        public static IAsyncResult BeginCopy(this Session session, string filespaceId, string path, string newFilespaceId, string newPath, bool replace, AsyncCallback callback, object state)
        {
            return BeginCopy(session, filespaceId, path, newFilespaceId, newPath, replace, null, null, callback, state);
        }

        public static void EndCopy(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((Copy)ar).EndCall();
        }

        public static void Copy(this Session session, string filespaceId, string path, string newFilespaceId, string newPath, bool replace, bool? merge, DateTime? versionTime)
        {
            new Copy(session).Call(filespaceId, path, newFilespaceId, newPath, replace, merge, versionTime);
        }

        public static void Copy(this Session session, string filespaceId, string path, string newFilespaceId, string newPath, bool replace)
        {
            new Copy(session).Call(filespaceId, path, newFilespaceId, newPath, replace, null, null);
        }

        #endregion
    }
}