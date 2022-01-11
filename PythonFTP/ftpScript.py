import os
import ftplib
import io


def listLineCallback(line):

    msg = "** %s*"%line;

    print(msg);

def loadFileToServer(serverURL, username, password, filePath, src):
    ftp = ftplib.FTP(serverURL)
    ftp.login(username, password)
    fileObject = open(src,"rb")
    ftp.storbinary("STOR " + filePath, fileObject)
    fileObject.close()
    respMessage = ftp.retrlines("LIST", listLineCallback)
    print(respMessage)
    ftp.close()

def saveFileFromServer(serverURL, username, password, filePath, dest):
    ftp = ftplib.FTP(serverURL)
    ftp.login(username, password)
    os.chdir(dest)
    fileObject = open(filePath,"wb")
    ftp.retrbinary("RETR " + filePath, fileObject.write)
    fileObject.close()
    ftp.close()

loadFileToServer("ftp.dlptest.com","dlpuser","rNrKYTX9g7z3RgJRmxWuGHbeu", "EvaluationHowProg.pdf", "C:/src/EvaluationHowProg.pdf")
saveFileFromServer("ftp.dlptest.com","dlpuser","rNrKYTX9g7z3RgJRmxWuGHbeu", "EvaluationHowProg.pdf", "C:/dest/pdfs")


#alle Ordner und Dateien im aktuellen Verzeichnis vom Server anzeigen
#respMessage = ftp.retrlines("LIST", listLineCallback)
#print(respMessage)
