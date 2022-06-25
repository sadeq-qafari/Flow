::[Bat To Exe Converter]
::
::YAwzoRdxOk+EWAjk
::fBw5plQjdCyDJGyX8VAjFAhVSAGFAE+1EbsQ5+n//NaDsEQLUfAsNobY1dQ=
::YAwzuBVtJxjWCl3EqQJgSA==
::ZR4luwNxJguZRRnk
::Yhs/ulQjdF+5
::cxAkpRVqdFKZSDk=
::cBs/ulQjdF+5
::ZR41oxFsdFKZSDk=
::eBoioBt6dFKZSDk=
::cRo6pxp7LAbNWATEpCI=
::egkzugNsPRvcWATEpCI=
::dAsiuh18IRvcCxnZtBJQ
::cRYluBh/LU+EWAnk
::YxY4rhs+aU+JeA==
::cxY6rQJ7JhzQF1fEqQJQ
::ZQ05rAF9IBncCkqN+0xwdVs0
::ZQ05rAF9IAHYFVzEqQJQ
::eg0/rx1wNQPfEVWB+kM9LVsJDGQ=
::fBEirQZwNQPfEVWB+kM9LVsJDGQ=
::cRolqwZ3JBvQF1fEqQJQ
::dhA7uBVwLU+EWDk=
::YQ03rBFzNR3SWATElA==
::dhAmsQZ3MwfNWATElA==
::ZQ0/vhVqMQ3MEVWAtB9wSA==
::Zg8zqx1/OA3MEVWAtB9wSA==
::dhA7pRFwIByZRRnk
::Zh4grVQjdCyDJGmW+0g1Kw9HcCKOM3yGFLAQ7eno6tWFo1kOaMsxa5va1ri9JfIF40bhZtgozn86
::YB416Ek+ZG8=
::
::
::978f952a14a936cc963da21a135fa983
nssm install Flow_Api %cd%\Api.bat
nssm start Flow_Api
nssm install Flow_Cdn %cd%\Cdn.bat
nssm start Flow_Cdn
nssm install Flow_Core %cd%\Core.bat
nssm start Flow_Core
nssm install Flow_Flow %cd%\Flow.bat
nssm start Flow_Flow
nssm install Flow_Identity %cd%\Identity.bat
nssm start Flow_Identity
nssm install Flow_Tenant %cd%\Tenant.bat
nssm start Flow_Tenant
nssm install Flow_Panel %cd%\Panel.bat
nssm start Flow_Panel
exits