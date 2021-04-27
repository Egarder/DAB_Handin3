How to use the application:

Step A:

1) Choose a random connection string from your SQL server.

2) Open the "BirthClinicPlanningDB" project, and open the "Context.cs" file. 

3) Replace the connection string with you own connection string in the "OnConfiguring()" method, AND edit the "Catalog" assignment to a name of your choice. 
   Press save. 

4) Set the "BirthClinicPlanningDB" project as your startup project. 

5) Go to your "Package Manager Console" and set "Package source" to "All", AND "Default Project" as "BirthClinicPlanningDB".

6) In the package manager console, type: "update-database", to apply the included migration files to the database. (The DB will be created on its own with seeded data) 

7) Ensure that the tables has been created in your local database. 


======================================   Now you are ready to run the application  =========================================


Step B:

1) Set the "BirthClinicGUI" as you startup project. 

2) Run the application by pushing the "F5" button. The WPF application will now start. 


====================================== Use cases to try ======================================

Step C:

UC1 - Add an appointment)

1. Press the "Add Appointment"-button. 

2. Put in room number. Ex: 1

3. Choose what room you want for the appointment - if you choose the maternityroom you will be asked to fill in info for the baby.

4. Change the timeframe with start time at the current date and time + 1 minute. 

5. Add one or more of the many clinicians.

6. Put in the Moms CPR-number - this must be a real cpr number - the application uses the "check11" to validate cpr numbers

7. Add the name of the mom and if you want, you can add the dad aswell - his CPR must be a real one also.

8. Press "Ok" and the appointment is added. 

 - Continue next use case to see your data....


UC2 - See rooms status)

1. Press the "See room status"-button

2. Choose the room you just added and appointment to. 

3. When the appointment has started, you will see that the room is occupied, and the data for the people who's in it. 

4) Go back, and choose another room without a current appointment. You'll find it empty ;-)


UC3 - Delete appointment)

1. On the mainwindow - choose the appointment you just created and click on "Delete Appointment" button

2. the appointment is now deleted

3. If you'd like, you can go to the database table and see that your appointment no longer exists. 


UC4 - Explore)

1. Double click at the "Clinicians" grid in the main window to the right for an appointment. (You'll see the clinicians added to the appointment)

2. Double click an appointment at the main window. (Now you'll see all the details for the appointment)



======================================   Clean up  =========================================


Step D:

1) Right click at the database at your local sql server, and delete the database. 

Now you are ready to start over from step A. 