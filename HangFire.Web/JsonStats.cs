﻿// This file is part of HangFire.
// Copyright © 2013 Sergey Odinokov.
// 
// HangFire is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// HangFire is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with HangFire.  If not, see <http://www.gnu.org/licenses/>.

using System.Linq;
using System.Text;
using System.Web;
using ServiceStack.Text;

namespace HangFire.Web
{
    internal class JsonStats : GenericHandler
    {
        public override void ProcessRequest()
        {
            var response = JobStorage.GetStatistics();

            using (JsConfig.With(emitCamelCaseNames: true))
            {
                var serialized = JsonSerializer.SerializeToString(response);
                Response.ContentType = "application/json";
                Response.ContentEncoding = Encoding.UTF8;
                Response.Write(serialized);
            }
        }
    }
}