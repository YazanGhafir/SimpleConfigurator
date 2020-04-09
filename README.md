# SimpleConfigurator
Automated Configurator project. The frontend is developed on React.js. The backend is developed on ASP.NET. 

![Feature Model](Documentation/FeatureModel.png "Product Feature Model")


# System Design and Architecture
The project is developed in an object-oriented manner as 2 different microservices (the backend project and the frontend project). The communication is defined by the REST API that is provided by the webservice controller in the backend. 

## Backend - Top down
  - ConfigController
    - is the simaple main controller that provide DataToSend endpoint via Get request. 
    - CORS is enabled exclusivly for the frontend origin with port 3000. 
  - Model
    - Entities: generated classes from the given database, handled by using ConfiguratorDataModel class that has object of all of these entities.
    - Buisness logic: Here the data of the products and there parameters as well as the rules and there parameters are gathered and formed in a way that maximizes the performance of handling it by the frontend.
      - RulesHandler: The most interesting part, this class uses GenericDAO and models the rules, parameters and values to inner classes and form them to constraints with 2 parameters or with 3 parameters in a way that make it easy and with high performance to handle the data in the frontend. 
      - ProductHandler: uses GenericDAO to gather the data of the parameters saved in Dictionary<string, Dictionary<int, string>> Parameters;
      - DataToSend: has both 
      ```
      Dictionary<string, Dictionary<int, string>> Parameters;
      List<List<int>> ConstraintsList;
      ```
      which will be converted to Json object and sent as a response to the frontend call via the endpoint in the controller.
      
      The sended data has the following form:
      ```
      {
        "Parameters": {
          "Lift type": {
          "1": "4000",
          "2": "6000",
          "3": "7000",
          "4": "9000"
          },
          "Outdoor": {
          "5": "Yes",
          "6": "No"
          },
          "Power supply": {
          "7": "230 V, 1-phase, 50 Hz",
          "8": "230 V, 3-phase, 60 Hz",
          "9": "380 V, 3-phase, 60 Hz",
          "10": "400 V, 3-phase, 50 Hz"
          },
          "Country of installation": {
          "11": "Austria",
          "12": "Netherlands",
          "13": "Sweden",
          "14": "United States",
          "15": "Taiwan"
          }
        },
        "ConstraintsList": [
          [2,5],
          [4,5],
          [7,14],
          [7,15],
          [10,14],
          [10,15],
          [8,11],
          [8,12],
          [8,13],
          [9,11],
          [9,12],
          [9,13],
          [1,9]
          ]
        }
        ```
        The each sublist of length 2 in ConstraintsList indicates to the frontend that its elements are mutually exclusive. For example, [2,5] says that the fifth radio button must be disabled when the second one is marked and vice versa.
  - DAO
    - GenericDAO is part of Model package but is sperated in its functionality from the entities.
    - Its main work is to handle the data base and provide the buisness logic classes the needed data from the data base by proper functionality.

## Frontend
  - Single page application design where the pages shares the nav-bar and the footer.
  - The routing is done centrally and relativly in App.js
  - The code is written as components and composite componenets.
  - The main-page shows the product alternatives using React Material Design cards.
  - The Nav-bar is done using React Bootstrap.
  - The Containers are flexboxes using React Bootstrap.
  - When you click on Lift, then Lift-component sends get request to the backend to get the data and save it in its state. 
  - Lift-component loopes over the gotten parameters and creates ListGroupItem component for each one that render the title of the radio-buttons-block.
  - Each ListGroupItem component creates RadioItem component that render shows the radio buttons with there lables.
  
  
  # The power-points of the project


