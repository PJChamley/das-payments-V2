﻿Feature: DLOCK03-When no matching record found in an employer digital account for for the standard code then datalock DLOCK_03 will be produced PV2-664
		
		As a Provider,
		I want to be notified with a DLOCK03 when no matching record found in an employer digital account for the Standard Code
		So that I can correct the data mis-match between the Commitment and ILR

Scenario Outline: DLOCK03-When no matching record found in an employer digital account for for the standard code then datalock DLOCK_03 will be produced PV2-664
	Given the employer levy account balance in collection period R12/Current Academic Year is 10000
	And the following commitments exist
		| Identifier       | standard code | programme type | agreed price | start date                   | end date                  | status | effective from               |
		| Apprenticeship a | 21            | 25             | 10000        | 01/Aug/CurrentAcademic Year | 01/Aug/Next Academic Year | active | 01/Aug/CurrentAcademic Year |
	And the provider is providing training for the following learners
		| Start Date                  | Planned Duration | Total Training Price | Total Training Price Effective Date | Total Assessment Price | Total Assessment Price Effective Date | Actual Duration | Completion Status | Contract Type | Aim Sequence Number | Aim Reference | Standard Code | Programme Type | Funding Line Type                                  | SFA Contribution Percentage |
		| 01/Aug/CurrentAcademic Year | 12 months        | 9000                 | 01/Aug/CurrentAcademic Year         | 1000                   | 01/Aug/CurrentAcademic Year           |                 | continuing        | Act1          | 1                   | ZPROG001      | 23            | 25             | 16-18 Apprenticeship (From May 2017) Levy Contract | 90%                         |
    And price details as follows
		| Price Episode Id  | Total Training Price | Total Training Price Effective Date | Total Assessment Price | Total Assessment Price Effective Date | Contract Type  | SFA Contribution Percentage |
		| pe-1              | 9000                 | 01/Aug/CurrentAcademic Year        | 1000                   | 01/Aug/CurrentAcademic Year          | Act1           | 90%                         |
	When the ILR file is submitted for the learners for collection period <Collection_Period>
	Then the following learner earnings should be generated
		| Delivery Period           | On-Programme | Completion | Balancing | First16To18EmployerIncentive | First16To18ProviderIncentive | Second16To18EmployerIncentive | Second16To18ProviderIncentive | LearningSupport | Price Episode Identifier |
		| Aug/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| Sep/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| Oct/Current Academic Year | 666.66667    | 0          | 0         | 500                          | 500                          | 0                             | 0                             | 150             | pe-1                     |
		| Nov/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| Dec/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| Jan/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| Feb/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| Mar/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| Apr/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| May/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| Jun/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 0                             | 0                             | 150             | pe-1                     |
		| Jul/Current Academic Year | 666.66667    | 0          | 0         | 0                            | 0                            | 500                           | 500                           | 150             | pe-1                     |
    And the following data lock failures were generated
        | Apprenticeship   | Delivery Period           | Standard Code | Programme Type | Transaction Type | Error Code | Price Episode Identifier |
        | Apprenticeship a | Aug/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Sep/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Oct/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Nov/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Dec/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Jan/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Feb/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Mar/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Apr/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | May/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Jun/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |
        | Apprenticeship a | Jul/Current Academic Year | 23            | 25             | Learning         | DLOCK_03   | pe-1                     |

	And Month end is triggered
	And no provider payments will be recorded
	And no provider payments will be generated
	


Examples:
    | Collection_Period         |
	| R01/Current Academic Year |
	| R02/Current Academic Year |
	| R03/Current Academic Year |
	| R04/Current Academic Year |
	| R05/Current Academic Year |
	| R06/Current Academic Year |
	| R07/Current Academic Year |
	| R08/Current Academic Year |
	| R09/Current Academic Year |
	| R10/Current Academic Year |
	| R11/Current Academic Year |
	| R12/Current Academic Year |








#Scenario: DLOCK03 - When no matching record found in an employer digital account for for the standard code then datalock DLOCK_03 will be produced
#   
#   Given the following commitments exist:
#   
#        | commitment Id | version Id | Provider   | ULN       | standard code | agreed price | start date | end date   | status | effective from |
#        | 73            | 73-125     | Provider a | learner a | 21            | 10000        | 01/05/2018 | 01/05/2019 | active | 01/05/2018     |
#        
#    When an ILR file is submitted with the following data:  
#	
#        | Provider   | ULN       | standard code | start date | planned end date | completion status | Total training price | Total training price effective date | Total assessment price | Total assessment price effective date |
#        | Provider a | learner a | 23            | 01/05/2018 | 08/08/2019       | continuing        | 9000                 | 01/05/2018                          | 1000                   | 01/05/2018                            |
#    
#    Then the following data lock event is returned:
#	
#        | Price Episode identifier  | Apprenticeship Id | ULN       | ILR Start Date | ILR Training Price | ILR End point assessment price  | 
#        | 25-23-01/05/2018          | 73                | learner a | 01/05/2018     | 9000               | 1000                            |
#    
#	And the data lock event has the following errors:   
#	
#        | Price Episode identifier  | Error code | Error Description										                      |
#        | 25-23-01/05/2018          | DLOCK_03   | No matching record found in the employer digital account for the standard code |
#    
#	And the data lock event has the following periods: 
#	
#        | Price Episode identifier | Period   | Payable Flag | Transaction Type |
#        | 25-23-01/05/2018         | 1718-R10 | false        | Learning         |
#        | 25-23-01/05/2018         | 1718-R11 | false        | Learning         |
#        | 25-23-01/05/2018         | 1718-R12 | false        | Learning         |
#    
#	And the data lock event used the following commitments:
#	
#        | Price Episode identifier | Apprentice Version | Start Date | standard code | Negotiated Price | Effective Date |
#        | 25-23-01/05/2018         | 73-125             | 01/05/2018 | 21            | 10000            | 01/05/2018     |

