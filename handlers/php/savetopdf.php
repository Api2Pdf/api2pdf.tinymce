<?	
    require ('api2pdf.php'); //or wherever you have stored the file
	
    $data = json_decode(file_get_contents('php://input'), true);        			
    $a2p_client = new Api2PdfLibrary('YOURAPIKEY');
    $api_response = $a2p_client->headless_chrome_from_html($data["content"]);
    		
    $response = array();
    $response["pdfUrl"] = $api_response->pdf;
    
    echo(json_encode($response));    
?>