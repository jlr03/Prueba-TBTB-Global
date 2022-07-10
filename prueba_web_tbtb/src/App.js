import React, { useEffect, useState } from 'react';
import './App.css';
import Filter from './Filter';

function App() {
  
  let componentMounted = true;
    const [data, setData] = useState([]);

    useEffect(() => {
        const loadUser = async () => {

            const response = await fetch("https://jsonplaceholder.typicode.com/users");
            if (componentMounted) {
                setData(await response.json());
            }

            return () => {
                componentMounted = false;
            };
        };

        loadUser();
    }, []);

  return (
    <div className="App">
        <Filter data={data}/>
    </div>
  );
}

export default App;
