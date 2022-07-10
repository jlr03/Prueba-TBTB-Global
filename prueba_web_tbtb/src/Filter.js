import React, {useState } from 'react';
import CardWorker from './CardWorker';
import TableWorker from './TableWorker';

const Filter = (data) => {

    const [users, setUsers] = useState(data.data);
    const [view, setView] = useState(true);

    const [value, setValue] = useState("");
    const [option, setOption] = useState("");

    const handleReset = () => { };

    let componentMounted = true;
    const handleSearch = async (e) => {

        e.preventDefault();

        const response = await fetch(`https://jsonplaceholder.typicode.com/users?q=${value}`);

        if (componentMounted) {
            setUsers(await response.json());
            setValue("")
        }

        return () => {
            componentMounted = false;
        };
    };

    const handleSort = async (e) => {

        let value = e.target.value
        setOption(value)

        const response = await fetch(`https://jsonplaceholder.typicode.com/users?_sort=${value}&_order=asc`);

        if (componentMounted) {
            setUsers(await response.json());
        }

        return () => {
            componentMounted = false;
        };
    };


    return (
        <>
            <div className="container">
                <div className="row">
                    <div className="col-12 col-lg-12 my-5 d-flex justify-content-center">
                        <div class="btn-group me-2" role="group" aria-label="Second group">
                            <button type="button" class="btn btn-secondary" onClick={()=>setView(true)}>Vista 1</button>
                            <button type="button" class="btn btn-secondary" onClick={()=>setView(false)}>Vista 2</button>
                        </div>
                    </div>
                </div>
            </div>
            <div className="container">
                <div className="row g-3">
                    <div className="col-6 col-lg-6 g-3 d-flex justify-content-center">
                        <form className="row" onSubmit={handleSearch}>
                            <div className="col-auto">
                                
                                <input type="text" className="form-control" placeholder="Escribe una palabra clave" value={value} onChange={(e) => setValue(e.target.value)} />
                            </div>
                            <div className="col-auto">
                                <button type="submit" className="btn btn-primary mb-3">Buscar</button>
                            </div>
                            <div className="col-auto">
                                <button type="submit" className="btn btn-primary mb-3" onClick={() => handleReset()}>Resetear</button>
                            </div>
                        </form>
                    </div>
                    <div className="col-6 col-lg-6 ps-5">
                        <select className="form-select" style={{width: "250px"}} onChange={handleSort} value={option}>
                            <option selected>Selecione una opción</option>
                            <option value="name">Name</option>
                            <option value="website">Web Site</option>
                            <option value="address.city">City</option>
                        </select>
                    </div>
                </div>
            </div>

            {view ? <TableWorker data={users}/> : <CardWorker data={users}/>} 
        </>
    );

}

export default Filter;