import React, { useState } from 'react';
import axios from 'axios';

export default function ItemCreateForm(props) {

    const [formData, setFormData] = useState([]);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        const postToCreate = {
            name: formData.name,
            information: formData.information
        };
        axios.post('http://localhost:5148/api/listpage',{postToCreate})
        .then(response => {
            console.log(response);
            console.log(response.data);
        })
        .catch(error => {
            console.log(error);
        });

    };

    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Create new post</h1>

            <div className="mt-5">
                <label className="h3 form-label">Item name</label>
                <input value={formData.name} name="title" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-4">
                <label className="h3 form-label">Item information</label>
                <input value={formData.information} name="content" type="text" className="form-control" onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onPostCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    );
}
