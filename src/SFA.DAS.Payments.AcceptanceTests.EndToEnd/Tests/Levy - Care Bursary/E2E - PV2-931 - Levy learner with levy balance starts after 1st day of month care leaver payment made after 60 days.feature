﻿

#Feature: Care Leaver Bursary
#
#Scenario: Levy learner with Levy balance, starts learning after first day of month, care leaver payment made after 60 days 
#
#	Given the learner is programme only Levy
#	And the apprenticeship funding band maximum is 9000
#	And levy balance > agreed price for all months
#
#	And the following commitment exists:
#        | ULN       | start date | end date   | agreed price | status |
#        | learner a | 03/08/2018 | 08/08/2019 | 7500         | active |	
#
#	When an ILR file is submitted with the following data:
#        | ULN       | learner type       | agreed price | start date | planned end date | actual end date | completion status | LearnDelFAM |
#        | learner a | programme only DAS | 7500         | 03/08/2018 | 08/08/2019       |                 | continuing        | EEF4        |
#		
#
#		
#	Then the provider earnings and payments break down as follows:
#        | Type                                    | 08/18 | 09/18 | 09/18 | 11/18 | 12/18 | 
#        | Provider Earned total                   | 500   | 500   | 1500  | 500   | 500   | 
#        | Provider Earned from SFA                | 500   | 500   | 1500  | 500   | 500   | 
#        | Provider Earned from Employer           | 0     | 0     | 0     | 0     | 0     | 
#        | Provider Paid by SFA                    | 0     | 500   | 500   | 1500  | 500   | 
#        | Payment due from Employer               | 0     | 0     | 0     | 0     | 0     | 
#        | Levy account debited                    | 0     | 500   | 500   | 500   | 500   | 
#        | SFA Levy employer budget                | 500   | 500   | 500   | 500   | 500   | 
#        | SFA Levy co-funding budget              | 0     | 0     | 0     | 0     | 0     | 
#        | SFA Levy additional payments budget     | 0     | 0     | 1000  | 0     | 0     |		
#        | SFA non-Levy co-funding budget          | 0     | 0     | 0     | 0     | 0     | 
#        | SFA non-Levy additional payments budget | 0     | 0     | 0     | 0     | 0     |
#
#	And the transaction types for the payments are:
#        | Payment type                   		  | 09/18 | 10/18 | 11/18 | 12/18 |  
#        | On-program                     		  | 500   | 500   | 500   | 500   |  
#        | Completion                     		  | 0     | 0     | 0     | 0     |  
#        | Balancing                      		  | 0     | 0     | 0     | 0     |  
#        | Employer 16-18 incentive       		  | 0     | 0     | 0     | 0     |  
#        | Provider 16-18 incentive       		  | 0     | 0     | 0     | 0     |  
#        | Framework uplift on-program    		  | 0     | 0     | 0     | 0     |  
#        | Framework uplift completion    		  | 0     | 0     | 0     | 0     |  
#        | Framework uplift balancing     		  | 0     | 0     | 0     | 0     |  
#        | Provider disadvantage uplift   		  | 0     | 0     | 0     | 0     |
#        | Care leaver apprentice payment 		  | 0     | 0     | 1000  | 0     |
#		
#NOTES:
## For new starts from 1 August 2018
## Care leaver apprentice payment is triggered after 60 days from start date
## Payment is triggered using EEF code 4


# *************************************
# For DC Integration
# | LearnDelFAM |
# | EEF4        |
# *************************************

Feature: Levy learner with levy balance starts after 1st day of month care leaver payment made after 60 days - PV2-931
		As a Provider,
		I want a Levy learner with levy balance, where the learner is a care leaver and starts learning after first day of the month, and earns a care leaver payment after 60 days 
		So that I am paid the correct apprenticeship funding by SFA - PV2-931

Scenario Outline: Levy learner with levy balance starts after 1st day of month care leaver payment made after 60 days - PV2-931

	Given the employer levy account balance in collection period <Collection_Period> is <Levy Balance>

	And the following commitments exist
        | start date                   | end date                  | agreed price | status | Framework Code | Pathway Code | Programme Type |
        | 03/Aug/Current Academic Year | 08/Aug/Next Academic Year | 7500         | active | 593            | 1            | 20             |

	And  the provider is providing training for the following learners
		| Start Date                   | Planned Duration | Total Training Price | Total Training Price Effective Date | Total Assessment Price | Total Assessment Price Effective Date | Actual Duration | Completion Status | Contract Type | Aim Sequence Number | Aim Reference | Framework Code | Pathway Code | Programme Type | Funding Line Type                                                   | SFA Contribution Percentage |
		| 03/Aug/Current Academic Year | 12 months        | 7500                 | 03/Aug/Current Academic Year        |                        |                                       |                 | continuing        | Act1          | 1                   | ZPROG001      | 593            | 1            | 20             | 19+ Apprenticeship (From May 2017) Non-Levy Contract (non-procured) | 90%                         |

	And price details as follows		
        | Price Episode Id | Total Training Price | Total Training Price Effective Date | Total Assessment Price | Total Assessment Price Effective Date | Contract Type | Aim Sequence Number | SFA Contribution Percentage |
        | pe-1             | 7500                 | 03/Aug/Current Academic Year        |                        | 03/Aug/Current Academic Year          | Act1          | 1                   | 90%                         |
    When the ILR file is submitted for the learners for collection period <Collection_Period>

	# New column - CareLeaverApprenticePayment
	Then the following learner earnings should be generated
		| Delivery Period           | On-Programme | Completion | Balancing | CareLeaverApprenticePayment | Price Episode Identifier |
		| Aug/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| Sep/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| Oct/Current Academic Year | 500          | 0          | 0         | 1000                        | pe-1                     |
		| Nov/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| Dec/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| Jan/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| Feb/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| Mar/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| Apr/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| May/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| Jun/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |
		| Jul/Current Academic Year | 500          | 0          | 0         | 0                           | pe-1                     |

	And at month end only the following payments will be calculated
		| Collection Period         | Delivery Period           | On-Programme | Completion | Balancing | CareLeaverApprenticePayment |
		| R01/Current Academic Year | Aug/Current Academic Year | 500          | 0          | 0         | 0                           |
		| R02/Current Academic Year | Sep/Current Academic Year | 500          | 0          | 0         | 0                           |
		| R03/Current Academic Year | Oct/Current Academic Year | 500          | 0          | 0         | 1000                        |

	# New transaction type - CareLeaverApprenticePayment
	And only the following provider payments will be recorded
		| Collection Period         | Delivery Period           | Levy Payments | SFA Fully-Funded Payments | Transaction Type            |
		| R01/Current Academic Year | Aug/Current Academic Year | 500           | 0                         | Learning                    |
		| R02/Current Academic Year | Sep/Current Academic Year | 500           | 0                         | Learning                    |
		| R03/Current Academic Year | Oct/Current Academic Year | 500           | 0                         | Learning                    |
		| R03/Current Academic Year | Oct/Current Academic Year | 0             | 1000                      | CareLeaverApprenticePayment |

	And only the following provider payments will be generated
		| Collection Period         | Delivery Period           | Levy Payments | SFA Fully-Funded Payments | Transaction Type            |
		| R01/Current Academic Year | Aug/Current Academic Year | 500           | 0                         | Learning                    |
		| R02/Current Academic Year | Sep/Current Academic Year | 500           | 0                         | Learning                    |
		| R03/Current Academic Year | Oct/Current Academic Year | 500           | 0                         | Learning                    |
		| R03/Current Academic Year | Oct/Current Academic Year | 0             | 1000                      | CareLeaverApprenticePayment |

Examples:
		| Collection_Period         | Levy Balance |
		| R01/Current Academic Year | 8000         |
		| R02/Current Academic Year | 7500         |
		| R03/Current Academic Year | 7000         |