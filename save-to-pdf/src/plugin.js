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
          window.location.href = result.pdfUrl;
          document.body.style.cursor='default';

        }
      };

      xhr.send(JSON.stringify({content: editor.getContent()}));
      document.body.style.cursor='wait';

    }
  });
};

export default plugin;
