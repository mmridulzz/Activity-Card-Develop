import React, { useState} from "react";
import { connect } from "react-redux";
import * as actions2 from "../actions/teacher";
import * as actions from "../actions/classes";
import * as actions1 from "../actions/teacherclasses";
import * as actions3 from "../actions/notification";
import { Drawer, Form, Button, Col, Row, Input, Select } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import { notification } from 'antd';
const { Option } = Select;
const Classesform = ({ ...props }) => {
    const [visible, setvisible] = useState(false);
    const [yearId, setyearid] = useState(0)
    const showDrawer = () => {
        setvisible(true)
    };
    const onClose = () => {
        setvisible(false)
        props.setcurrentId(currentId=>currentId+1)
    };
    const callSchoolYear = e => {
        setyearid(e)  
    }
    function handleChange(value) {
        console.log(`selected `, value);
    }
    const callTeacher = () => {
        props.fetchAllTeacher()
    }
    const onSubmit=(values)=>
    {
        console.log("classlist", props.classList)
        const { classname,  TId: [ ...rest ]} = values
        //console.log(rest)
        const args = {
            message: 'Update Notification ',
            description:
                'Successfully Updated',
            duration: 0,
        };
        const onSuccess = () => {
            notification.open(args);
        }
        const onSuccess2 = () => {
            console.log("teacher added")
        }
        const onSuccess1 = () => {
            console.log("notification added")
        }
        const val = {
            classname, yearId, TId: [...rest] }
        props.createClass(val, onSuccess)
        const val1 = {
            "message": "class" + classname+" added", "Readstatus": "no", "NUserId": localStorage.getItem('userid') }
        
        props.createNotification(val1, onSuccess1)
      
        console.log("the real", val)
    }
    return (
        <>
            <Button type="primary" onClick={showDrawer}>
                <PlusOutlined /> New account
            </Button>
            <Drawer
                title="Create a new account"
                width={720}
                onClose={onClose}
                visible={visible}
                bodyStyle={{ paddingBottom: 80 }}
                
            >
                <Form layout="vertical" hideRequiredMark onFinish={onSubmit}>
                    <Row gutter={16}>
                        <Col span={12}>
                            <Form.Item
                                name="yearid"
                                label="Type"
                                rules={[{ required: true, message: 'Please choose the year' }]}
                            >
                                <Select placeholder="Please choose the Year" onSelect={callSchoolYear}>
                                    <Option value="1">5</Option>
                                    <Option value="2">6</Option>
                                </Select>
                            </Form.Item>
                        </Col>
                        <Col span={12}>
                            <Form.Item
                                name="classname"
                                label="Class Name"
                                rules={[{ required: true}]}
                            >
                                <Input />
                            </Form.Item>
                        </Col>
                    </Row>
                    <Row gutter={16}>
                        <Col span={12}>
                            <Form.Item
                                name="TId"
                                label="Type1"
                                rules={[{ required: true, message: 'Please choose the year' }]}
                            >
                                <Select
                                    mode="multiple"
                                    style={{ width: '100%' }}
                                    placeholder="select one country"
                                    onChange={handleChange}
                                    onClick={callTeacher}
                                    optionLabelProp="label"
                                >
                                    {
                                        props.teacherList.map((record, index) => {
                                            return (
                                                <Option key={index} value={record?.tId} label={record.user?.firstName}>
                                                    {record.user?.firstName}
                                                </Option>)
                                        })}
                                </Select>
                            </Form.Item>
                        </Col>
                    </Row>
                    <Row gutter={16}>
                        <Col span={12}>
                    <Form.Item >
                                <Button type="primary" htmlType="submit" style={{ marginRight: 8 }} >
                                    Submit 
                                </Button>
                                <Button onClick={onClose} style={{ marginRight: 8 }}>
                                    Cancel
                                </Button>
                    </Form.Item>
                        </Col>
                    </Row>
                </Form>
            </Drawer>
        </>
         );
}


const mapStateToProps = state => ({
    teacherList: state.teacher.list,
    teacherClassList: state.teacherclasses.list,
    classList: state.classes.list
})

const mapActionToProps = {
    fetchAllTeacher: actions2.fetchAll,
    createClass: actions.create,
    createTeacherClass: actions1.create,
    createNotification: actions3.create
}

export default connect(mapStateToProps, mapActionToProps)(Classesform);