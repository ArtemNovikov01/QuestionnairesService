'use client';

import { BuisnessmanType } from "@/app/shared/models/enums/BuisnessmanType";
import { MainEvents } from './main-page-events';
import React, { useState } from "react";
import "./main-page.css"

const selectEvent = new MainEvents()

export default function Main(){
  const [selectedComponent, setSelectedComponent] = useState<React.ReactNode>(null);

  return (
    <div className="row">
      <div className="col-4">
      <p className="custom-paragraph">Форма собственности</p>
      <label className="form-text custom-label">Вид деятельности*</label>
      <select
        className="form-select"
        onChange={(e) => selectEvent.selectType(e.target.value as unknown as BuisnessmanType, setSelectedComponent)}
        aria-label="Default select example"
      >
        <option value="" hidden>Выберите тип бизнеса</option>
        <option value={BuisnessmanType.IndividualEntrepreneur}>
          Индивидуальный предприниматель (ИП)
        </option>
        <option value={BuisnessmanType.LimitedLiabilityCompany}>
          Общество с ограниченной ответственностью (ООО)
        </option>
      </select>
      </div>
      {selectedComponent}
    </div>
  );
}