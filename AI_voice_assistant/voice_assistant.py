from ast import main
import audioop
from cgitb import text
import datetime
from re import search
from urllib import request
import webbrowser
import pyttsx3
import speech_recognition as sr
import wikipedia
import os
import random
import requests
from bs4 import BeautifulSoup
import subprocess as sp
import pyautogui 

engine=pyttsx3.init('sapi5')   #speech api to take voice 
voices=engine.getProperty('voices') #taking engine property of voices 
#print(voices[1].id)  #id 0 for male 1 for female
engine.setProperty('voice',voices[1].id)
#The smtplib module defines an SMTP client session object that can be used to send mail to any internet machine with an SMTP or ESMTP listener daemon.
paths = {
    'notepad': "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Accessories\\Notepad",
    'paint': "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Accessories\\Paint",
    'calculator': "C:\\Windows\\System32\\calc.exe"
}
def open_notepad():
    os.startfile(paths['notepad'])

def open_paint():
    os.startfile(paths['paint'])

def open_calculator():
    os.startfile(paths['calculator'])
    
def open_camera():
    sp.run('start microsoft.windows.camera:', shell=True)

def speak(audio):
    engine.say(audio) #here audio is played
    engine.runAndWait()  #run and then wait for speech before exiting    
def screenshot():
    img=pyautogui.screenshot()
    img.save("C:\\Users\\user\\OneDrive\\Desktop\\ss\\ss.png")    
def get_random_joke():
    headers = {
        'Accept': 'application/json'
    }
    res = requests.get("https://icanhazdadjoke.com/", headers=headers).json()
    return res["joke"]

def wishMe():
     hour=int(datetime.datetime.now().hour)
     if hour>=0 and hour<12:
          speak("GOOD MORNING")
          
     elif hour>=12 and hour<18:
          speak("GOOD AFTERNOON")
          
     else:    
          speak("GOOD EVENING")
          
     speak("I am EL sir. Please tell me how may i help you")

def takecommand():
    #it takes mic input from the user and return a string output
    r=sr.Recognizer()
    with sr.Microphone() as source:
        print("Listening.....")
        r.pause_threshold=1   #seconds of non speaking audio b4 a phase is considered complete
        audio=r.listen(source)

        
    try:
        print("Recognizing....")
        query=r.recognize_google(audio,language='en-PK')
        print("User said: ",query)      

    except Exception as e:
        #print(e)
        print("Say that again please....")
        return "None"
#energy threshold brhao agr shor recognize ni krwana chaty ap
    return query

if __name__ == "__main__":
    
    wishMe()
    while True:
        query=takecommand().lower()
        #logic for executing takes based on query 
        if 'wikipedia' in query:
            speak('Searching Wikipedia...')
            query = query.replace("wikipedia", "")
            results = wikipedia.summary(query, sentences = 2)
            speak("According to wikipedia ")
            print(results)
            speak(results)
            
        elif 'open youtube' in query:
            webbrowser.open("youtube.com")
            
        elif 'open google' in query:
            webbrowser.open("google.com")
            
        elif 'open stack overflow' in query:
            webbrowser.open("stackoverflow.com")
          
        elif 'play music' in query:
           music_dir='C:\\songs'
           songs=os.listdir(music_dir) 
           #print(songs)
           x=random.randint(0,2)
           os.startfile(os.path.join(music_dir,songs[x]))       
           
        elif 'the time' in query:
           strTime=datetime.datetime.now().strftime("%H:%M:%S")
           speak(f"SIR The time is {strTime}")
           
        elif 'open vs code' in query:
            vscode="C:\\Users\\fati-noor\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe"
            os.startfile(vscode)
           
        elif 'open pictures' in query:
            pictures='G:\PICTURES\\New folder\\BARAT'
            os.startfile(pictures)
    
        elif 'camera' in query:
            open_camera()
           
        elif 'notepad' in query:
            open_notepad()   
           
        elif 'calculator' in query:
            open_calculator()
        
        elif 'paint' in query:
            open_paint()
        
        elif 'screenshot' in query:
            screenshot()
            speak("Screenshot captured")
          
        elif 'joke' in query:
             speak(f"Hope you like this one sir")
             joke = get_random_joke()
             speak(joke)
             speak("For your convenience, I am printing it on the screen sir.")
             print(joke)    
        elif 'temperature' in query:
             search="temperature in lahore"
             url=f"https://www.google.com/search?client=firefox-b-d&q={search}"
             r=requests.get(url)
             data=BeautifulSoup(r.text,"html.parser")
             temp=data.find("div",class_="BNeaWE").text
             speak(temp)
    
        elif 'netflix' in query:
            webbrowser.open("netflix.com")
        
        
        
        
             