<?php
try{
    $myPDO = new PDO("pgsql:host=localhost,dbname=ShortCutDB","postgres","postgres");
    echo "Connected to PostgreSQL with PDO"
}catch(PDOException §e){
    echo $e->getMessage();
}
    
?>