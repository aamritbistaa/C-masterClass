1. User Service
Feature: Handles registration, login, password management, and role assignment.

Use: Central place for identity and access control. Validates credentials and issues JWT tokens or session tokens.

Example: Doctors, admins, and patients use this to log into the system.




User setups => role => based on the role => 


User setup flow
    1. User enters his details and his desired role, onboarding status requested, IsVerified = false
       1. Super Admin approves user (incase of Staff) 
    2. Email is generated with password
    3. Use logins with password (status is authenticated)
    4. User uploads documents (document requirement wil be different based on roles) and extra information regarding the roles
    5. Staff verifies documents (onboarding status is completed) IsVerified = true -> update it in user authentication database also

When ever user logs in check if user is verified or not



OTP
 -> Fail count
 -> Attempt count
 -> Expiry time
 Same screen ma basera otp check garirakhda fail count will increase, back gayera/ request otp garda chai attempt count ni badhcha
 OTP valid vayessi chai expiry time herincha
