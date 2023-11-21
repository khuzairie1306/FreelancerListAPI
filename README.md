# Freelancer
# Details
- microsoft visual studio 2022
- Microsoft Sql Server
- File Database Attach as "**Freelancers.bak**"

Step To Test (By Swagger to Restful API)

1) Listing of Freelance
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/476fd824-8310-4895-8584-6b2f45beabad)
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/e9ba8a8a-c223-4a38-81e4-1e20765950ae)


2) Create user Freelance
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/9370e8dd-3d4f-4fde-aab7-8403587a1722)
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/6bd58e54-e198-4f82-aad9-2bcc1d59299a)
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/e5858fe9-5010-43fd-93b5-6cb46676deff)

   . Click api getallusers to see the list of user that has been created (follow step 1)
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/eb6d5288-da4f-42cc-a451-3fbba6fc5413)
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/17f1e89f-d3ac-41db-bc22-654ddc263242)


3) Update user Freelance -> example i will update on id 16 that i has been created before this on step 2
   -fetch response using /api/Users/GetUsers/{id}
   -after that copy response body and paste into update API /api/Users/UpdateUser
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/01c0a9c9-10a1-4f23-90df-598429bf263a)
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/551bac77-1b96-4ff2-818c-988eef729dd7)
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/d102c50e-cb53-4f0d-931e-f06b4b21fe60)


4) Delete User ->keyin id example for me is "16" for parameter

   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/bd9cbca1-611b-45c3-8f95-9ab88fd000e9)
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/7337d610-d4f2-4daf-9cde-40321dd55110)


Step To Test (User Interface)
Run Application 

1) Listing of Freelance
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/526cd47d-f84c-48c5-99be-48dd48d0e869)

2) Create Freelance Record -> click button create new and will display below UI
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/e514d6ca-f2ac-4847-a628-86466445a4b4)

3) After success will redirect to List
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/e6483ea5-d8c8-4556-a47d-338b993a015a)

4) Edit  -> for edit can click link "**Edit**" in listing and will diplay UI as below 
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/34c7c9f7-aa47-4435-aaf2-9e26771e3280)

5) After Update Success it will redirect to Index list Freelance

   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/1fe673b3-c86e-428b-8cd8-d91bfb95bee1)

6) Delete - > Click Link "**Delete**" into index list of freelance above and will display picture as attachment below
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/85d01ff0-cc25-4f65-9a67-c19678f4af58)

7)  It will show success delete user
   ![image](https://github.com/khuzairie1306/FreelancerListAPI/assets/151608761/cc22cece-81e8-48dc-9c22-8c2952246c5b)

