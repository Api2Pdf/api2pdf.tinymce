# api2pdf.tinymce
TinyMCE Plugin Code for [Api2Pdf REST API](https://www.api2pdf.com/documentation) 

Api2Pdf.com is a REST API for instantly generating PDF documents from HTML, URLs, Microsoft Office Documents (Word, Excel, PPT), and images. The API also supports merge / concatenation of two or more PDFs. Api2Pdf is a wrapper for popular libraries such as **wkhtmltopdf**, **Headless Chrome**, and **LibreOffice**.

This plugin adds a Save to PDF functionality to TinyMCE.  It will take the HTML contents of your editor, convert it to PDF, and request the web browser to download it.

The plugin will add a menu option to the toolbar to Save to PDF.  It will also add an icon.
![image](https://user-images.githubusercontent.com/7950956/44163612-e6f02500-a091-11e8-8897-e59a4e7eafcb.png)
***
- [Get Started with TinyMCE CDN](#tinymce-cdn)
- [Get Started TinyMCE Self Hosted](#tinymce-self)
- [Handlers and API Key](#handler)
- [PHP Handler](#php)
- [ASP.NET MVC](#mvc)
- [ASP.NET Core MVC](#mvccore)
- [ASP.NET Classic (ashx)](#ashx)
- [FAQ](https://www.api2pdf.com/faq)


## <a name="tinymce-cdn"></a>Get Started with TinyMCE CDN
This sample HTML initializes TinyMCE via CDN and loads the latest Save-to-Pdf plugin via CDN.  This example HTML replaces all textareas in a document to use TinyMCE loaded via CDN.  Take a look at the init method, to make use of the save to pdf plugin you should take note of the following steps:

1. Register savetoPdf in the external_plugins section
2. If you wish to have a toolbar icon, register saveToPdf in your list of toolbar icons
3. Finally you must set the handler.  For more information on the handler [see this section](#handler)

```html
<!DOCTYPE html>
<html>
<head>
    <script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
    <script>
        tinymce.init({
            selector: 'textarea',
            external_plugins:
                {
                    'saveToPdf': 'https://cdn.rawgit.com/Api2Pdf/api2pdf.tinymce/master/save-to-pdf/dist/save-to-pdf/plugin.js'
                },
            toolbar: 'saveToPdf',
            saveToPdfHandler: '/REPLACE-WITH-HANDLER-URL'
    });
    </script>
</head>
<body>
    <textarea>Testing saveToPdf</textarea>
</body>
</html>
```

## <a name="tinymce-self"></a>Get Started with TinyMCE Self Hosted
This sample HTML assumes TinyMCE is running from your local code base.  It also assumes that you have downloaded the save-to-pdf plugin code from the repo (https://github.com/Api2Pdf/api2pdf.tinymce/tree/master/save-to-pdf/dist/save-to-pdf) and saved to your tinyMCE plugins folder (/tinymce/plugins/saveToPdf/plugin.js).

1. Register savetoPdf in the external_plugins section
2. If you wish to have a toolbar icon, register saveToPdf in your list of toolbar icons
3. Finally you must set the handler.  For more information on the handler [see this section](#handler)

```html
<!DOCTYPE html>
<html>
<head>
    <script src="//scripts/tinymce.min.js"></script>
    <script>
        tinymce.init({
            selector: 'textarea',
            plugins: 'saveToPdf'                
            toolbar: 'saveToPdf',
            saveToPdfHandler: '/REPLACE-WITH-HANDLER-URL'
    });
    </script>
</head>
<body>
    <textarea>Testing saveToPdf</textarea>
</body>
</html>
```
