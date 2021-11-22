// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CMPG_323_Project_2.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using CMPG_323_Project_2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\_Imports.razor"
using CMPG_323_Project_2.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\Pages\Main.razor"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\Pages\Main.razor"
using DataLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\Pages\Main.razor"
using CMPG_323_Project_2.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/main")]
    public partial class Main : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 55 "C:\Users\Deadman\Desktop\CMPG323 - Project 2\CMPG-323-Project-2\CMPG-323-Project-2\Pages\Main.razor"
       

    ImageModel Images = new ImageModel();
    UsersModel user = new UsersModel();
    List<ImageModel> pictures;
    List<UsersModel> users;
    private string Uname = Login.Name;
    private string pic;
    public static string Image { get; set; }
    public static string Image2 { get; set; }
    public bool copyimage = false;
    public bool nullvalue = false;
    public bool notfound = false;
    public string picname;
    public static byte[] ArImages { get; set; }


    protected override async Task OnInitializedAsync()
    {

        string sql = "select * from images WHERE Username = @username";
        pictures = await _data.LoadData<ImageModel, dynamic>(sql, new {username = Uname }, _config.GetConnectionString("default"));

        string sql2 = "select ProfilePicture from useraccount ";
        users = await _data.LoadData<UsersModel, dynamic>(sql2, new { username = Uname }, _config.GetConnectionString("default"));

        Image =  Login.Profilepic;

    }

    private async Task FileChange(InputFileChangeEventArgs fileChangeEvent)
    {
        var file = fileChangeEvent.File;

        var buffer = new byte[file.Size];
        await file.OpenReadStream(1512000).ReadAsync(buffer);
        pic = $"data:image/png;base64,{Convert.ToBase64String(buffer)}";
        Image = $"data:image/png;base64,{Convert.ToBase64String(buffer)}";
    }

    private async Task UploadImages(InputFileChangeEventArgs fileChangeEvent)
    {

        var file = fileChangeEvent.GetMultipleFiles();
        for(int i = 0; i < file.Count; i++)
        {
            var buffer = new byte[file[i].Size];
            await file[i].OpenReadStream(1512000).ReadAsync(buffer);
            Image2 = $"data:image/png;base64,{Convert.ToBase64String(buffer)}";
            foreach(var I in pictures)
            {
                if (file[i].Name == I.Image_Name)
                {
                    copyimage = true;
                    return;
                }
            }

            string sql = "insert into images(image_name,Image,Username) values (@imagename,@image,@username); ";
            await _data.SaveData(sql, new {imagename = file[i].Name, image = Image2, username = Uname}, _config.GetConnectionString("default"));

            string sql2 = "select * from images WHERE Username = @username";
            pictures = await _data.LoadData<ImageModel, dynamic>(sql2, new { username = Uname }, _config.GetConnectionString("default"));
            copyimage = false;
        }

    }

    private async Task Upload()
    {
        string sql2 = "update useraccount SET profilepicture = @image WHERE Username = @username";

        await _data.SaveData(sql2, new { image = Image, username = Uname }, _config.GetConnectionString("default"));

        Login.Profilepic = pic;
    }

    public async Task Deleteenable()
    {
        foreach(var I in pictures)
        {
            if (Images.Image_Name == I.Image_Name)
            {
                nullvalue = false;
                string sql = "DELETE FROM images WHERE image_name = @imagename";
                await _data.SaveData(sql, new { imagename = Images.Image_Name }, _config.GetConnectionString("default"));

                string sql2 = "select * from images WHERE Username = @username";
                pictures = await _data.LoadData<ImageModel, dynamic>(sql2, new { username = Uname }, _config.GetConnectionString("default"));
                notfound = false;
                nullvalue = false;
                return;

            }else if (Images.Image_Name == null || Images.Image_Name == "")
            {
                notfound = false;
                nullvalue = true;
                return;
            }else if (Images.Image_Name != I.Image_Name)
            {
                nullvalue = false;
                notfound = true;
                return;
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager Nav { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IConfiguration _config { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDataAccess _data { get; set; }
    }
}
#pragma warning restore 1591
