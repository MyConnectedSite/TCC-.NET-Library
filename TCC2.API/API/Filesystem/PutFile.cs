using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TCC2.API.Filesystem
{
    public class PutFile : ApiCallBase<PutFileResult>
    {
        protected override string Url
        {
            get { return "putfile"; }
        }

        public PutFile(Session session)
            : base(session)
        {
        }

        public void BeginCall(PutFileItem file, string deleteCookie, string clientType, AsyncCallback callback, object state)
        {
            BeginCall(new PutFileItem[] { file }, deleteCookie, clientType, callback, state);
        }

        public void BeginCall(IEnumerable<PutFileItem> files, string deleteCookie, string clientType, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (files == null)
                throw new ArgumentNullException("files");

            switch (files.Take(2).Count())
            {
                case 1: AddItem(files.First(), String.Empty); break;
                case 2:
                    {
                        int itemsCount = 0;
                        foreach (PutFileItem item in files)
                        {
                            itemsCount++;
                            AddItem(item, itemsCount.ToString(CultureInfo.InvariantCulture));
                        }
                        AddParameter("upcount", itemsCount);

                        break;
                    }
                default: throw new ArgumentException("No files to upload");
            }

            AddParameter("deleteCookie", deleteCookie);
            AddParameter("clientType", clientType);
            BeginCall(callback, state);
        }

        public PutFileResult Call(PutFileItem file, string deleteCookie, string clientType)
        {
            BeginCall(file, deleteCookie, clientType, null, null);
            return EndCall();
        }

        public PutFileResult Call(IEnumerable<PutFileItem> files, string deleteCookie, string clientType)
        {
            BeginCall(files, deleteCookie, clientType, null, null);
            return EndCall();
        }

        protected override IRequest GetDefaultRequest()
        {
            return Session.CreatePostRequest();
        }

        void AddItem(PutFileItem item, string suffix)
        {
            if (item.Offset.HasValue) {
                AddAttachment("partialfile" + suffix, new BinaryAttachment(item.Data, item.Length, "partialfile" + suffix));
            } else {
                AddAttachment("upfile" + suffix, new BinaryAttachment(item.Data, item.Length, "upfile" + suffix));
            }
            AddParameterOrEmptyPlaceholder("filespaceId" + suffix, item.FilespaceId);
            AddParameterOrEmptyPlaceholder("entryId" + suffix, item.EntryId);
            AddParameterOrEmptyPlaceholder("path" + suffix, item.Path);
            AddParameter("replace" + suffix, item.Replace);
            AddParameterOrEmptyPlaceholder("memberId" + suffix, item.MemberId);
            AddParameterOrEmptyPlaceholder("createTime" + suffix, item.CreateTime);
            AddParameterOrEmptyPlaceholder("modifyTime" + suffix, item.ModifyTime);
            AddParameterOrEmptyPlaceholder("versionTime" + suffix, item.VersionTime);
            AddParameterOrEmptyPlaceholder("localModifyTime" + suffix, item.LocalModifyTime);
            AddParameter("hidden" + suffix, item.Hidden);
            AddParameterOrEmptyPlaceholder("startPosition" + suffix, item.Offset);
            AddParameterOrEmptyPlaceholder("commitUpload" + suffix, item.Commit);
        }
    }
}