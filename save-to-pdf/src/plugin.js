import _ from 'lodash';

const plugin = (editor, url) => {
  editor.addMenuItem('saveToPdf', {
    text: 'Save to PDF',
    context: 'file',
    image: "//cdn.rawgit.com/Api2Pdf/api2pdf.tinymce/master/save-to-pdf/src/icon.svg",
    onclick: () => {}
  });

  editor.addButton('saveToPdf', {
    title: "Save to PDF",
    image: "//cdn.rawgit.com/Api2Pdf/api2pdf.tinymce/master/save-to-pdf/src/icon.svg",
    onclick: () => {
      //Do POST without JQUERY
      var xhr = new XMLHttpRequest();
      xhr.open('POST', editor.settings.saveToPdfHandler);
      xhr.setRequestHeader('Content-Type', 'application/json');      
      xhr.onload = function() 
      {
        if (xhr.status === 200) {
          var result = JSON.parse(xhr.responseText);

          if(result && result.pdfUrl)
            window.location.href = result.pdfUrl;
          else
            console.log(xhr.resposneText);
            
          document.body.style.cursor='default';
        }
        else
        {
          document.body.style.cursor='default';
          console.log("Error generating pdf");
        }
      };

      xhr.send(JSON.stringify({content: editor.getContent()}));
      document.body.style.cursor='wait';

    }
  });
};

export default plugin;
